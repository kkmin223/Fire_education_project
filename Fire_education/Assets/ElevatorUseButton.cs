using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class ElevatorUseButton : MonoBehaviour
    {
        [SerializeField]
        private TestButton button = null;

        [SerializeField]
        private GameObject ObjectToScale = null;

        [SerializeField]
        private float ScaleIncrement = 1.0f;

        [SerializeField]
        private buttonAction ButtonAction = buttonAction.M2;

        private enum buttonAction { M1, M2, M3, M4, M5, M6, M7, Reset, Grow, Shrink,Elevator };
        public static ElevatorUseButton CUBInstance;
        public int press = 0;
        private Vector3 InitialScale;
        AudioSource audioSource;
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
                        audioSource.Play();
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
                    case buttonAction.Elevator:
                        
                        break;

                }
            }

            button.Selected = false;
        }
    }
}
