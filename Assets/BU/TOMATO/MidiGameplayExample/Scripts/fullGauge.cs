using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Notero.RaindropGameplay.UI
{


    public class fullGauge : MonoBehaviour
    {
        public GameObject objCP;
        private ComboPanel cp;
        [SerializeField] private ParticleSystem wolfgangGood;
        [SerializeField] private ParticleSystem poppyPerfect;
        [SerializeField] private ParticleSystem kevinOops;
        // Start is called before the first frame update
        void Start()
        {
            

        }



        // Update is called once per frame
        void Update()
        {
            GameObject objCp = GameObject.Find("ComboPanel");
            ComboPanel cp = objCP.GetComponent<ComboPanel>();

         
        }

        void CheckPerfectObject()
        {
            
            if (GameObject.Find("vfx_good_old") != null)
            {
                
                wolfgangGood.Play();
            }

            if (GameObject.Find("vfx_perfect_old") != null)
            {
                poppyPerfect.Play();
            }

            if (GameObject.Find("vfx_oops_old") != null)
            {
                kevinOops.Play();
            }
        }
    }
}
