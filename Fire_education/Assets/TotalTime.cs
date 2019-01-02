using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using UnityEditor;
using System.Text;

public class TotalTime : MonoBehaviour {

    public Text Label1;
    public float m = 0f;
    public static TotalTime totalTimeInstance;
    //Use this for initialization
    private void Awake()
    {
        if (!totalTimeInstance)
            totalTimeInstance = this;
    }
    // Use this for initialization
    void Start () {
        Label1 = GetComponent<Text>();
        m = Time_count.TimeInstance.LimitTime;
        Label1.text = "Time:   " + m.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
   
}
