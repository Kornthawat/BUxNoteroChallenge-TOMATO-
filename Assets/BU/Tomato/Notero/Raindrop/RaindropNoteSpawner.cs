using Notero.Unity.MidiNoteInfo;
using Notero.Unity.UI.VirtualPiano;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Notero.TOMATO.Raindrop
{
    public class RaindropNoteSpawner : MonoBehaviour
    {
        [SerializeField] protected RaindropNote m_WhiteLeftSeed;
        [SerializeField] protected RaindropNote m_WhiteRightSeed;
        [SerializeField] protected RaindropNote m_BlackLeftSeed;
        [SerializeField] protected RaindropNote m_BlackRightSeed;
        [SerializeField] protected RectTransform m_WhiteRaindropContainer;
        [SerializeField] protected RectTransform m_BlackRaindropContainer;

        public List<float> LanePositionList { get; protected set; }
        public float PianoFitWidth { get; protected set; }
        public virtual Vector3 Position => ((RectTransform)transform).position;

        protected int m_MinimumKeyGiven;
        protected float m_RaindropSpeed;
        protected float m_WhiteKeySize;
        protected float m_BlackKeySize;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="octaveInputAmount"></param>
        /// <param name="minimumKeyGiven"></param>
        /// <param name="speed"></param>
        /// <param name="spawnPosition"></param>
        public virtual void Init(int octaveInputAmount, int minimumKeyGiven, float speed, float spawnPosition)
        {
            m_RaindropSpeed = speed;
            float containerWidth = ((RectTransform)transform).rect.width;
            m_WhiteKeySize = ((RectTransform)m_WhiteLeftSeed.transform).rect.width;
            m_BlackKeySize = ((RectTransform)m_BlackLeftSeed.transform).rect.width;
            m_MinimumKeyGiven = minimumKeyGiven;
            LanePositionList = VirtualPianoHelper.GetLanePosition(containerWidth, m_WhiteKeySize, m_BlackKeySize, octaveInputAmount);
            PianoFitWidth = LanePositionList.Last() - LanePositionList.First() + m_WhiteKeySize;
            SetSpawnerPosition(spawnPosition);
        }

        /// <summary>
        /// Retrun a rendered Raindrop note coresponding to the info.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public virtual RaindropNote Create(MidiNoteInfo info)
        {
            int notePosIndex = info.MidiId - m_MinimumKeyGiven;
            float xPos = LanePositionList[notePosIndex];
            return PoolNewRaindropNote(info, new Vector2(xPos, 0));
        }

        public virtual void SetRaindropSpeed(float speed) => m_RaindropSpeed = speed;

        protected virtual void SetSpawnerPosition(float yPos)
        {
            RectTransform rect = (RectTransform)transform;
            float xPos = rect.anchoredPosition.x;
            rect.anchoredPosition = new Vector2(xPos, yPos);
        }

        protected RaindropNote GetRaindropNoteType(MidiNoteInfo info)
        {
            if(info.TrackIndex == (int)Handside.Left)
            {
                return VirtualPianoHelper.IsBlackKey(info.MidiId) ? m_BlackLeftSeed : m_WhiteLeftSeed;
            }
            else
            {
                return VirtualPianoHelper.IsBlackKey(info.MidiId) ? m_BlackRightSeed : m_WhiteRightSeed;
            }
        }

        protected RaindropNote PoolNewRaindropNote(MidiNoteInfo info, Vector2 pos)
        {
            var container = VirtualPianoHelper.IsBlackKey(info.MidiId) ? m_BlackRaindropContainer : m_WhiteRaindropContainer;
            RaindropNote raindropGo = GetRaindropNoteType(info).Rent(container);
            raindropGo.SetMidiInfo(info);
            raindropGo.name = VirtualPianoHelper.GetNoteName(info.MidiId);
            RectTransform rect = (RectTransform)raindropGo.transform;
            rect.localScale = Vector3.one;
            rect.anchoredPosition = pos;
            return raindropGo;
        }
    }
}