using UnityEngine;
using UnityEngine.UI;

namespace Notero.RaindropGameplay.UI
{
    public class ComboPanel : MonoBehaviour
    {
       
            [SerializeField] GameObject box1;
            [SerializeField] GameObject box2;
            [SerializeField] GameObject box3;
            [SerializeField] GameObject box4;
            [SerializeField] GameObject box5;
            [SerializeField] GameObject box6;
            [SerializeField] GameObject box7;
            [SerializeField] GameObject box8;
            [SerializeField] GameObject box9;
            [SerializeField] GameObject box10;
            [SerializeField] GameObject box11;

            [SerializeField] GameObject bg;
            [SerializeField] GameObject fadeBG;
            public float scoreC = 5;
           
         
            // Start is called before the first frame update
           

            // Update is called once per frame
            void Update()
            {
            
                if (Input.GetKeyUp(KeyCode.A))
                {
                    CheckPerfect();
                }

                if (Input.GetKeyUp(KeyCode.S))
                {
                    CheckPerfect();
                }

                if (Input.GetKeyUp(KeyCode.D))
                {
                    CheckPerfect();
                }

            if (Input.GetKeyUp(KeyCode.F))
            {
                CheckPerfect();
            }

            if (Input.GetKeyUp(KeyCode.G))
            {
                CheckPerfect();
            }

            if (Input.GetKeyUp(KeyCode.H))
            {
                CheckPerfect();
            }

            CheckScore();


            }

            void CheckPerfect()
            {
                Debug.Log(scoreC);
                if (GameObject.Find("vfx_good_old") != null)
                {
                    scoreC = scoreC + 1000f;
                }

                if (GameObject.Find("vfx_perfect_old") != null)
                {
                    scoreC = scoreC + 2000f;
                }

                if (GameObject.Find("vfx_oops_old") != null)
                {
                    scoreC = scoreC + 0f;
                }
            }

            void CheckScore()
            {

                if (scoreC >= 1000f)
                {
                    box1.SetActive(true);
                }

                if (scoreC >= 5000f)
                {
                    box2.SetActive(true);
                }

                if (scoreC >= 10000f)
                {
                    box3.SetActive(true);
                }

                if (scoreC >= 15000f)
                {
                    box4.SetActive(true);
                }

                if (scoreC >= 20000f)
                {
                    box5.SetActive(true);
                }

                if (scoreC >= 25000f)
                {
                    box6.SetActive(true);
                }

                if (scoreC >= 30000f)
                {
                    box7.SetActive(true);
                }

                if (scoreC >= 35000f)
                {
                    box8.SetActive(true);
                }

                if (scoreC >= 40000f)
                {
                    box9.SetActive(true);
                }

                if (scoreC >= 45000f)
                {
                    box10.SetActive(true);
                }

                if (scoreC >= 55000f)
                {
                    box11.SetActive(true);
                   fadeBG.SetActive(true);
              
                }

                if (scoreC < 1000f)
                {
                    box1.SetActive(false); 
                    box2.SetActive(false);
                    box3.SetActive(false);
                    box4.SetActive(false);
                    box5.SetActive(false);
                    box6.SetActive(false);
                    box7.SetActive(false);
                    box8.SetActive(false);
                    box9.SetActive(false);
                    box10.SetActive(false);
                    box11.SetActive(false);
                  
                }
            }




        
    }
}

