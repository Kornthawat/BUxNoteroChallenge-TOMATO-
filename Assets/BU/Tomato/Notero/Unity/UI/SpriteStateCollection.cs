using System;
using UnityEngine;

namespace Notero.TOMATO.Unity.UI
{
    /// <summary>
    /// Class that stores the collection of sprite transitions on a Selectable.
    /// </summary>
    [Serializable]
    public class SpriteStateCollection : TransitionStateCollection<SpriteState, Sprite> { }
}
