using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using UnityEditor;
using System.Text;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class behavior_script : MonoBehaviour
    {

        public Text Label;
        public int ScoreLabel = 0;
        public static behavior_script behaviorInstance;
        public static bool[] ActResult = new bool[10];

        private void Awake()
        {
            if (!behaviorInstance)
                behaviorInstance = this;
        }

        // Use this for initialization
        void Start()
        {
            //Label = GetComponent<Text>();
            //for (int i = 0; i < 10; i++)
            //    ActResult[i] = false;


        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < 9; i++)
            {
                if (Action_Limit.GetAct(i) == true)
                    ActResult[i] = true;

            }
        }
    }
}