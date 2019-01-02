// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity.Tests
{
    [RequireComponent(typeof(SetGlobalListener))]
    public class HapticsTest : MonoBehaviour, IInputHandler
    {
        public static HapticsTest hapticsTest;
        public bool seatValid = false;
        private void Awake()
        {
            if (!hapticsTest)
                hapticsTest = this;
        }
        void IInputHandler.OnInputDown(InputEventData eventData)
        {
            InteractionInputSource inputSource = eventData.InputSource as InteractionInputSource;
            if (inputSource != null)
            {
                switch (eventData.PressType)
                {
                    case InteractionSourcePressInfo.Grasp:
                        //inputSource.StartHaptics(eventData.SourceId, 1.0f);
                        Debug.Log("GRAPEPEPEPEPEPEP!!!");
                        seatValid = true;
                        return;
                    case InteractionSourcePressInfo.Menu:
                        inputSource.StartHaptics(eventData.SourceId, 1.0f, 1.0f);
                        return;
                }
            }
        }

        void IInputHandler.OnInputUp(InputEventData eventData)
        {
            InteractionInputSource inputSource = eventData.InputSource as InteractionInputSource;
            if (inputSource != null)
            {
                if (eventData.PressType == InteractionSourcePressInfo.Grasp)
                {
                    Debug.Log("GRAPEPEPEPEPEPEP!!!UUUUUUUUUUUUUUUP");
                    seatValid = false;

                    //inputSource.StopHaptics(eventData.SourceId);
                }
            }
        }
    }
}
