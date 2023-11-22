using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Notero.RaindropGameplay.UI
{


    public class fullGauge : MonoBehaviour
    {
        public GameObject objCP;
        private ComboPanel cp;
        // Start is called before the first frame update
        void Start()
        {
            

        }



        // Update is called once per frame
        void Update()
        {
            GameObject objCp = GameObject.Find("ComboPanel");
            ComboPanel cp = objCP.GetComponent<ComboPanel>();

            if(cp.scoreC > 1000)
            {
                Debug.Log("Im Here");
            }
        }
    }
}
