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
    /// <summary>
    /// Script teleports the user to the location being gazed at when Y was pressed on a Gamepad.
    /// </summary>
    [RequireComponent(typeof(SetGlobalListener))]
    public class MixedRealityTeleport : Singleton<MixedRealityTeleport>, IControllerInputHandler
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
             AudioSource audioSource;
        [Tooltip("Makes sure you don't get put 'on top' of holograms, just on the floor. If true, your height won't change as a result of a teleport.")]
        public bool StayOnTheFloor = false;

        public float RotationSize = 2.0f;
        public float StrafeAmount = 0.2f;

        [SerializeField]
        private GameObject teleportMarker;
        private Animator animationController;

        [SerializeField]
        private bool useCustomMapping = false;

        /// <summary>
        /// The fade control allows us to fade out and fade in the scene.
        /// This is done to improve comfort when using an immersive display.
        /// </summary>


        private bool isTeleportValid;
        private IPointingSource currentPointingSource;
        private uint currentSourceId;

        private float LerpTime = 1.0f;
        AudioSource audioSourcef;
        private void Start()
        {
            // If we're on the HoloLens or no device is present,
            // remove this component.
#if UNITY_2017_2_OR_NEWER
            if (!XRDevice.isPresent
#if UNITY_WSA
                || !HolographicSettings.IsDisplayOpaque
#endif
            )
#else
            if (VRDevice.isPresent)
#endif
            {
                Destroy(this);
                return;
            }
            audioSourcef = GetComponent<AudioSource>();
            colC = GetComponent<CapsuleCollider>();
        }

        private void Update()
        {
#if UNITY_WSA
            if (InteractionManager.numSourceStates == 0)
            {
                HandleGamepad();
            }
#endif
            CheckPosition(xMP, yMP);

            CheckSeat();
        }

        private void HandleGamepad()
        {

            float leftX = Input.GetAxis(useCustomMapping ? LeftThumbstickX : XboxControllerMapping.GetMapping(HorizontalStrafe));
            float leftY = Input.GetAxis(useCustomMapping ? LeftThumbstickY : XboxControllerMapping.GetMapping(ForwardMovement));
            bool pressBtn = Input.GetButtonDown(XboxControllerMapping.GetMapping(XboxControllerMappingTypes.XboxA));

            if (pressBtn)
            {
                Debug.Log("GetBtn1");
            }
            else
            {
                Debug.Log("NoneBtn1");
            }


            if (leftY > 0.8 && Math.Abs(leftX) < 0.3)
            {
                DoStrafe(Vector3.forward * StrafeAmount);
            }


            if (leftX < -0.8 && Math.Abs(leftY) < 0.3)
            {
                DoStrafe(Vector3.left * StrafeAmount);
            }
            else if (leftX > 0.8 && Math.Abs(leftY) < 0.3)
            {
                DoStrafe(Vector3.right * StrafeAmount);
            }
            else if (leftY < -0.8 && Math.Abs(leftX) < 0.3)
            {
                DoStrafe(Vector3.back * StrafeAmount);
            }


            float rightX = Input.GetAxis(useCustomMapping ? RightThumbstickX : XboxControllerMapping.GetMapping(HorizontalRotation));
            float rightY = Input.GetAxis(useCustomMapping ? RightThumbstickY : XboxControllerMapping.GetMapping(VerticalRotation));

            if (rightX < -0.8 && Math.Abs(rightY) < 0.3)
            {
                DoRotation(-RotationSize);
            }
            else if (rightX > 0.8 && Math.Abs(rightY) < 0.3)
            {
                DoRotation(RotationSize);
            }

        }

        void CheckPosition(float x, float y)
        {



            if (y > 0.8 && Math.Abs(x) < 0.3)
            {
                if (isMoveAbleF(Vector3.forward))
                    DoStrafe(Vector3.forward * StrafeAmount);
            }




            if (y < -0.8 && Math.Abs(x) < 0.3)
            {
                if (isMoveAbleB(Vector3.back))
                    DoStrafe(Vector3.back * StrafeAmount);
            }


            if (x < -0.8 && Math.Abs(y) < 0.3)
            {
                DoRotation(-RotationSize);
            }
            else if (x > 0.8 && Math.Abs(y) < 0.3)
            {
                DoRotation(RotationSize);
            }
        }

        float xMP = 0;
        float yMP = 0;

        void IControllerInputHandler.OnInputPositionChanged(InputPositionEventData eventData)
        {
            InteractionInputSource inputSource = eventData.InputSource as InteractionInputSource;
     
            if (!HapticsTest.hapticsTest.seatValid)
            {
                if (Time_count.TimeInstance.getViveTime() < 0f)
                {
                    Time_count.TimeInstance.RecoveryViveTime();
                    Time_count.TimeInstance.RecoveryViveDueTime();
                    inputSource.StartHaptics(eventData.SourceId, 1.0f);
                }              
                else if (Time_count.TimeInstance.getViveDueTime() < 0f )
                {
                    inputSource.StopHaptics(eventData.SourceId);
                }
     
            }
            else 
            {
                inputSource.StopHaptics(eventData.SourceId);
            }



            if (eventData.PressType == InteractionSourcePressInfo.Thumbstick)
            {
                yMP = eventData.Position.y;
                xMP = eventData.Position.x;



                if (eventData.Position.y > 0.8 && Math.Abs(eventData.Position.x) < 0.3)
                {
                    if (isMoveAbleF(Vector3.forward))
                        DoStrafe(Vector3.forward * StrafeAmount);
                }



                if (eventData.Position.y < -0.8 && Math.Abs(eventData.Position.x) < 0.3)
                {
                    if (isMoveAbleB(Vector3.back))
                        DoStrafe(Vector3.back * StrafeAmount);
                }


                if (eventData.Position.x < -0.8 && Math.Abs(eventData.Position.y) < 0.3)
                {
                    DoRotation(-RotationSize);
                }
                else if (eventData.Position.x > 0.8 && Math.Abs(eventData.Position.y) < 0.3)
                {
                    DoRotation(RotationSize);
                }

            }


        }



        bool saveY = true;
        float saveYV = 0;
        float littleDown = 1;
        void CheckSeat()
        {

            if (HapticsTest.hapticsTest!=null&&HapticsTest.hapticsTest.seatValid)
            {

                if (saveY)
                {
                    saveYV = transform.position.y;
                    saveY = false;
                    littleDown = transform.position.y;
                }
                else
                {
                    if (littleDown <= 0)
                    {
                        Debug.Log(littleDown);
                        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
                    }
                    else
                    {
                        littleDown = littleDown - 0.08f;
                        transform.position = new Vector3(transform.position.x, littleDown, transform.position.z);
                    }


                }

            }
            else
            {
                if (!saveY)
                {
                    transform.position = new Vector3(transform.position.x, saveYV, transform.position.z);
                    littleDown = 1;
                    saveY = true;
                }
                //Debug.Log("NonCheckGrap2");
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                if ((int)Time_count.TimeInstance.getLimitTime() % 5 == 0)
                {

                    audioSourcef.Play();
                }
                //cough

            }
        }


        public void DoRotation(float rotationAmount)
        {
            if (rotationAmount != 0)
            {
                transform.RotateAround(CameraCache.Main.transform.position, Vector3.up, rotationAmount);
            }
        }




        string hitName;
        RaycastHit hit;
        CapsuleCollider colC;
        Boolean isMoveAbleF(Vector3 strafeAmount)
        {
            //Ray ray = CameraCache.Main.ScreenPointToRay(strafeAmount);

            bool ishit = Physics.Raycast(colC.transform.position, colC.transform.forward, out hit, 0.3f);

            if (ishit)
            {
                if (hit.collider != null)
                    hitName = hit.collider.gameObject.tag;

                if (hitName.Equals("ColliderWall"))
                {
                    Debug.Log("colliderwall");
                    return false;
                }
                else if (hitName.Equals("ColliderFire"))
                {
                    ProgressBarCircle.progressBarCircle.hurtHealth2();
                    iTween.ShakePosition(this.gameObject, Vector3.one, 0.3f);
                    return false;
                }
            }

            return true;
        }

        Boolean isMoveAbleB(Vector3 strafeAmount)
        {
            //Ray ray = CameraCache.Main.ScreenPointToRay(strafeAmount);

            bool ishit = Physics.Raycast(colC.transform.position, -colC.transform.forward, out hit, 1.0f);

            if (ishit)
            {
                if (hit.collider != null)
                    hitName = hit.collider.gameObject.tag;

                if (hitName.Equals("ColliderWall"))
                {
                    Debug.Log("colliderwall");
                    return false;
                }
                else if (hitName.Equals("ColliderFire"))
                {
                    ProgressBarCircle.progressBarCircle.hurtHealth2();
                    Debug.Log("colliderfire");
                    iTween.ShakePosition(this.gameObject, Vector3.one, 0.3f);
                    return false;
                }
            }

            return true;
        }

        public void DoStrafe(Vector3 strafeAmount)
        {


            if (strafeAmount.magnitude != 0)
            {
                Transform transformToRotate = CameraCache.Main.transform;
                transformToRotate.rotation = Quaternion.Euler(0, transformToRotate.rotation.eulerAngles.y, 0);
                transform.Translate(strafeAmount, CameraCache.Main.transform);
            }

        }


        private void EnableMarker()
        {
            teleportMarker.SetActive(true);
            if (animationController != null)
            {
                animationController.StartPlayback();
            }
        }

        private void DisableMarker()
        {
            if (animationController != null)
            {
                animationController.StopPlayback();
            }
            teleportMarker.SetActive(false);
        }
    }
}
