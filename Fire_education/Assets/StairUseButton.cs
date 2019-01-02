using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class StairUseButton : MonoBehaviour
    {
        [SerializeField]
        private TestButton button = null;

        [SerializeField]
        private GameObject ObjectToScale = null;

        [SerializeField]
        private float ScaleIncrement = 1.0f;

        [SerializeField]
        private buttonAction ButtonAction = buttonAction.Stair;
        bool was = false;
        private enum buttonAction { M1, M2, M3, M4, M5, M6, M7, Reset, Grow, Shrink, Bell,Stair };
        public static StairUseButton CUBInstance;
        public int press = 0;
        private Vector3 InitialScale;
        AudioSource audioSource=new AudioSource();
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

            if (ObjectToScale)
            {
                switch (ButtonAction)
                {
                    case buttonAction.M1:
                        ControlMenual.instance.Menual_1();
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.M2:
                        press = 2;
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
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.Bell:
                        score.scoreInstance.AddScore(100);
                        break;
                    case buttonAction.Stair:
                        if (Action_Limit.limit(8) && !was)
                        {
                            press = 2;
                            was = true;
                            score.scoreInstance.AddScore(100);
                            audioSource.Play();
                            if (DestroyFQ.DesInstance != null)
                                DestroyFQ.DesInstance.DesFQ();
                            if (DestroyMC.DesInstance != null)
                                DestroyMC.DesInstance.DesMC();
                            if (DestroyIM.DesInstance != null)
                                DestroyIM.DesInstance.DesIM();
                            if (DestroyLIC.DesInstance != null)
                                DestroyLIC.DesInstance.DesLIC();
                            if (DestroyRIC.DesInstance != null)
                                DestroyRIC.DesInstance.DesRIC();
                            if (DestroyDC.DesInstance != null)
                                DestroyDC.DesInstance.DesDC();
                            GameObject CameraParent = GameObject.Find("MixedRealityCameraParent (2)");
                            CameraParent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                            CameraParent.transform.position = new Vector3(6, 0, -227);
                            Application.LoadLevel("SuccessScene");
                           
                        }
                    
                       
                        break;
                }
            }

            button.Selected = false;
        }
    }
}
