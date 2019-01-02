using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class Door_Use_Button : MonoBehaviour
    {
        [SerializeField]
        private TestButton button = null;

        [SerializeField]
        private GameObject ObjectToScale = null;

        [SerializeField]
        private float ScaleIncrement = 1.0f;

        [SerializeField]
        private buttonAction ButtonAction = buttonAction.door;

        private enum buttonAction { M1, M2, M3, M4, M5, M6, M7, Reset, Grow, Shrink,door ,door1,door2};
        public static Door_Use_Button DUBInstance;
        private Vector3 InitialScale;
        AudioSource audioSource;
        public int press = 0;
        private float fire_life = 10f;
        private float hun = 0f;
        bool use_ext = false;

        void Awake()
        {
            if (!DUBInstance)
                DUBInstance = this;
            audioSource = GetComponent<AudioSource>();
        }
        private void Start()
        {
            if (ObjectToScale)
            {
                InitialScale = ObjectToScale.transform.localScale;
            }
           

        }

        private void OnEnable()
        {
            button.Activated += OnButtonPressed;
        }

        private void OnDisable()
        {
            button.Activated -= OnButtonPressed;
        }


        private void OnButtonPressed(TestButton source)
        {
            GameObject Firewall = GameObject.Find("WallOfFire");
            GameObject Door = GameObject.Find("Room_Door");
            GameObject Door_Main = Door.transform.GetChild(1).gameObject;
            //GameObject Bath_Door = GameObject.Find("Bath_Door");
            //GameObject Bath_Door_Main = Bath_Door.transform.GetChild(1).gameObject;
            //GameObject House_Door = GameObject.Find("House_Door");
            //GameObject House_Door_Main = House_Door.transform.GetChild(1).gameObject;
            if (ObjectToScale)
            {
                switch (ButtonAction)
                {
                    case buttonAction.M1:
                        ControlMenual.instance.Menual_1();
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.M2:
                        ControlMenual.instance.Menual_2();
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.M3:
                        ControlMenual.instance.Menual_3();
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.M4:
                        ControlMenual.instance.Menual_4();
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.M5:
                        ControlMenual.instance.Menual_5();
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.M6:
                        ControlMenual.instance.Menual_6();
                        use_ext = true;
                        audioSource.Play();
                        for (int i = 0; i < 10; i++)
                            Firewall.transform.localScale += new Vector3(0.2f, 0, 0.05f);
                        Destroy(Firewall, 5f);
                        

                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.door:
                        audioSource.Play();
                        press = 2;
                        Door_Main.transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
                        break;
                    //case buttonAction.door1:
                    //    Bath_Door_Main.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f));
                    //    break;
                    //case buttonAction.door2:
                    //    House_Door_Main.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f));
                    //    break;


                }
            }

            button.Selected = false;
        }
    
   }
}
