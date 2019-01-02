using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using UnityEditor;
using System.Text;

public class Total : MonoBehaviour
{

    public Text total;
    public float score;
    public float num;
    public static Total totalInstance;
    int i;
    // Use this for initialization
    private void Awake()
    {
        if (!totalInstance)
            totalInstance = this;

    }
    void Start()
    {
        total = GetComponent<Text>();

    }
    // Update is called once per frame
    void Update()
    {
        score = TotalTime.totalTimeInstance.m * 100 + TotalScore.totalScoreInstance.n;
        num = score;
        PlayerPrefs.SetFloat("Score", score);
        //PlayerPrefs.Save();
        total.text = "Total:   " + score.ToString();
    }

}