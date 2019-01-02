using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using UnityEditor;
using System.Text;
//using static System.String;

public class score : MonoBehaviour {
    public Text Label;
    public static int ScoreLabel=0;
    public static score scoreInstance;

          private void Awake()
    {
        if (!scoreInstance)
            scoreInstance = this;
    }
    // Use this for initialization
    void Start () {
        Label = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
      //  AddScore(1);
        //scorelabel=scoremaneger.Score.ToString();
	}
    public void AddScore(int num) {
        ScoreLabel += num;
       
        Label.text = "score  : " + ScoreLabel.ToString();
    }
    public static int getScoreLabel()
    {
        return ScoreLabel;
    }
    void test() {
        AddScore(10);
    }
}
