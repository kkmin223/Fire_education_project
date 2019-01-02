// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class SinkUseButton : MonoBehaviour
    {
        [SerializeField]
        private TestButton button = null;

        [SerializeField]
        private GameObject ObjectToScale = null;

        [SerializeField]
        private float ScaleIncrement = 1.0f;

        [SerializeField]
        private buttonAction ButtonAction = buttonAction.M5;
        bool was = false;
        private enum buttonAction { M1, M2, M3, M4, M5, M6, M7, Reset, Grow, Shrink };
        public static SinkUseButton SUBInstance;
        public int press = 0;
        private Vector3 InitialScale;
        AudioSource audioSource;
        void Awake()
        {
            if (!SUBInstance)
                SUBInstance = this;
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

            if (ObjectToScale)
            {
                switch (ButtonAction)
                {
                    case buttonAction.M1:
                        press = 1;
                        ControlMenual.instance.Menual_1();
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.M2:
                   
                        ControlMenual.instance.Menual_2();
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.M3:
                        press = 3;
                        ControlMenual.instance.Menual_3();
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.M4:
                        press = 4;
                        ControlMenual.instance.Menual_4();
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.M5:
                        if (Action_Limit.limit(4)&&!was)
                        {
                            was = true;
                            ControlMenual.instance.Menual_5();
                            audioSource.Play();
                            press = 2;
                            score.scoreInstance.AddScore(100);
                        }
                        break;
                    case buttonAction.M6:

                        ControlMenual.instance.Menual_6();
                        score.scoreInstance.AddScore(100);
                        break;

                }
            }

            button.Selected = false;
        }
    }
}