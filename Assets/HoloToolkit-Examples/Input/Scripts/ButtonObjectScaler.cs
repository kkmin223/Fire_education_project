// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class ButtonObjectScaler : MonoBehaviour
    {
        [SerializeField]
        private TestButton button = null;

        [SerializeField]
        private GameObject ObjectToScale = null;

        [SerializeField]
        private float ScaleIncrement = 1.0f;

        [SerializeField]
        private buttonAction ButtonAction = buttonAction.M6;
        bool was = false;
        private enum buttonAction { M1,M2,M3,M4,M5,M6, M7,  Reset, Grow, Shrink , door2 };
        public static ButtonObjectScaler CUBInstance;
        private Vector3 InitialScale;
        AudioSource audioSource;
        public static int pressLL = 0;
        private float fire_life = 10f;
        private float hun = 0f;
        bool use_ext = false;
       
        void Awake()
        {
            if (!CUBInstance)
                CUBInstance = this;
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
                        
                        if (Action_Limit.limit(5) && !was)
                        {
                            pressLL = 2;
                            was = true;
                            ControlMenual.instance.Menual_6();
                            Debug.Log(pressLL + "잡았다요놈");
                            audioSource.Play();
                            for (int i = 0; i < 10; i++)
                                Firewall.transform.localScale += new Vector3(0.2f, 0, 0.05f);
                            Destroy(Firewall, 5f);
                            score.scoreInstance.AddScore(200);

                        }
                        
                        break;

              

                }
            }

            button.Selected = false;
        }
    }
}