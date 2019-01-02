using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class Action_Limit : MonoBehaviour
    {
        [SerializeField]
        private TestButton button = null;
        [SerializeField]
        private buttonAction ButtonAction;
        private enum buttonAction { M1, M2, M3, M4, M5, M6, M7, Reset, Grow, Shrink, door, exit_home };
        static bool[] Act_Limit = new bool[10];
        
        /*
        1=핸드폰, 2=전원차단기, 3=수건, 4=세면대, 5=소화기,6=집 나가기,7=화재 비상벨,8=계단
         */
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
        public static bool GetAct(int index)
        {
            return Act_Limit[index];
        }
        public static bool limit(int act)
        {
            switch (act)
            {
                case 1:
                    Act_Limit[1] = true;
                    return Act_Limit[1];
                    
                case 2:
                    if (Act_Limit[1])
                        Act_Limit[2] = true;
                    return Act_Limit[2];
                case 3:
                    if (Act_Limit[2])
                        Act_Limit[3] = true;
                    return Act_Limit[3];
                    
                case 4:
                    if (Act_Limit[3])
                        Act_Limit[4] = true;
                    return Act_Limit[4];
                    
                case 5:
                    if (Act_Limit[4])
                        Act_Limit[5] = true;
                    return Act_Limit[5];
                case 6:
                    if (Act_Limit[5])
                        Act_Limit[6] = true;
                    return Act_Limit[6];
                case 7:
                    if (Act_Limit[6])
                        Act_Limit[7] = true;
                    return Act_Limit[7];
                case 8:
                    if (Act_Limit[7])
                        Act_Limit[8] = true;
                    return Act_Limit[8];

            }
            return false;
        }
    }
}
