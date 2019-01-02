// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;
using HoloToolkit.Unity.Tests;

#if UNITY_2017_2_OR_NEWER
using UnityEngine.XR;
#if UNITY_WSA
using UnityEngine.XR.WSA;
using UnityEngine.XR.WSA.Input;
#endif
#else
using UnityEngine.VR;
#if UNITY_WSA
using UnityEngine.VR.WSA.Input;
#endif
#endif

namespace HoloToolkit.Unity.InputModule
{
    [RequireComponent(typeof(SetGlobalListener))]
    public class IntroCode : Singleton<IntroCode>
    {
        [Tooltip("Name of the thumbstick axis to check for teleport and strafe.")]
        public XboxControllerMappingTypes HorizontalStrafe = XboxControllerMappingTypes.XboxLeftStickHorizontal;

        [Tooltip("Name of the thumbstick axis to check for movement forwards and backwards.")]
        public XboxControllerMappingTypes ForwardMovement = XboxControllerMappingTypes.XboxLeftStickVertical;

        [Tooltip("Name of the thumbstick axis to check for rotation.")]
        public XboxControllerMappingTypes HorizontalRotation = XboxControllerMappingTypes.XboxRightStickHorizontal;

        [Tooltip("Name of the thumbstick axis to check for rotation.")]
        public XboxControllerMappingTypes VerticalRotation = XboxControllerMappingTypes.XboxRightStickVertical;

        [Tooltip("Custom Input Mapping for horizontal teleport and strafe")]
        public string LeftThumbstickX = InputMappingAxisUtility.CONTROLLER_LEFT_STICK_HORIZONTAL;

        [Tooltip("Name of the thumbstick axis to check for movement forwards and backwards.")]
        public string LeftThumbstickY = InputMappingAxisUtility.CONTROLLER_LEFT_STICK_VERTICAL;

        [Tooltip("Custom Input Mapping for horizontal rotation")]
        public string RightThumbstickX = InputMappingAxisUtility.CONTROLLER_RIGHT_STICK_HORIZONTAL;

        [Tooltip("Custom Input Mapping for vertical rotation")]
        public string RightThumbstickY = InputMappingAxisUtility.CONTROLLER_RIGHT_STICK_VERTICAL;

        public bool EnableTeleport = true;
        public bool EnableRotation = true;
        public bool EnableStrafe = true;

        [Tooltip("Makes sure you don't get put 'on top' of holograms, just on the floor. If true, your height won't change as a result of a teleport.")]
        public bool StayOnTheFloor = false;

        public float RotationSize = 2.0f;
        public float StrafeAmount = 0.2f;
        private FadeManager fadeControl;

        [SerializeField]
        private GameObject teleportMarker;
        private Animator animationController;

   

        /// <summary>
        /// The fade control allows us to fade out and fade in the scene.
        /// This is done to improve comfort when using an immersive display.
        /// </summary>


        private bool isTeleportValid;
        private IPointingSource currentPointingSource;
        private uint currentSourceId;

 
        AudioSource audioSource;

        private void Start()
        {
            FadeManager.AssertIsInitialized();

            fadeControl = FadeManager.Instance;

            // If the FadeManager is missing,
            // remove this component.
            if (fadeControl == null)
            {
                Destroy(this);
                return;
            }


            //IntroFade(30.0f);
            audioSource = GetComponent<AudioSource>();
        }

        Boolean fade1 = true;
        Boolean fade2 = true;
        Boolean cough = true;
        private void Update()
        {
            if (fade1)
            {

                if (Time_count.TimeInstance.getFadeTime() < 4.8f)
                {
                    IntroFade1(30.0f);
                    fade1 = false;
                }
            }
            if (cough)
            {
                if (Time_count.TimeInstance.getFadeTime() < 3.3f)
                {
                    audioSource.Play();         
                    cough = false;
                }
            }

            if (fade2)
            {

                if (Time_count.TimeInstance.getFadeTime() < 1.9f)
                {
                    audioSource.Play();
                    IntroFade2(-30.0f);
                    fade2 = false;
                }
            }
        }

        public void IntroFade1(float rotationAmount)
        {

            fadeControl.DoFade(
                1.5f, // Fade out time
                1.2f, // Fade in time
                () => // Action after fade out
                {
                    transform.RotateAround(CameraCache.Main.transform.position, Vector3.up, rotationAmount);
                }, null); // Action after fade in

        }

        public void IntroFade2(float rotationAmount)
        {

            fadeControl.DoFade(
                0.8f, // Fade out time
                0.8f, // Fade in time
                () => // Action after fade out
                {
                    transform.RotateAround(CameraCache.Main.transform.position, Vector3.up, rotationAmount);
                }, null); // Action after fade in

        }

        public void IntroFirst(float rotationAmount)
        {

            fadeControl.DoFade(
                5.0f, // Fade out time
                5.0f, // Fade in time
                () => // Action after fade out
                {
                    transform.RotateAround(CameraCache.Main.transform.position, Vector3.up, rotationAmount);
                }, null); // Action after fade in

        }

    }
}