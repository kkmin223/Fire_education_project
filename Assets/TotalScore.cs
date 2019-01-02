using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using UnityEditor;
using System.Text;

public class TotalScore : MonoBehaviour {

    public Text Label;
    public float n = 0f;
    public static TotalScore totalScoreInstance;
    //Use this for initialization
    private void Awake()
    {
        if (!totalScoreInstance)
            totalScoreInstance = this;
    }

    void Start () {
        
        Label = GetComponent<Text>();
        n = score.getScoreLabel();
        Label.text = "score  : " + n.ToString();
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    //public void totalscore()
    //{
    //    n = score.getScoreLabel();

    //    Label.text = "score  : " + n.ToString();
    //}
}
