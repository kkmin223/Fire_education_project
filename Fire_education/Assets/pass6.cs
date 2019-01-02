using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Text;
using UnityEngine.UI;
namespace HoloToolkit.Unity.InputModule.Tests
{

    public class pass6 : MonoBehaviour
    {
        public Text Label;
        // Use this for initialization
        void Start()
        {
            Label = GetComponent<Text>();


        }

        // Update is called once per frame
        void Update()
        {
            if (behavior_script.ActResult[6] == true)
                Label.text = "OK";

        }
    }
}

