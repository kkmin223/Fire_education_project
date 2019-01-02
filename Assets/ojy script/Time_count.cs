using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.Tests;
using UnityEngine.SceneManagement;
public class Time_count : MonoBehaviour
{
    private float FadeTime = 5.0f;
    private float ViveTime = 6.0f;
    private float ViveDueTime = 1.5f;
    public float LimitTime = 60f;
    private float hun = 0f;
    public Text text;
    public static Time_count TimeInstance;
    //GameObject camera = GameObject.Find("MixedRealityCameraParent (2)");
    //GameObject IM = GameObject.Find("InputManager (2)");
    bool con = false;
    private void Awake()
    {
        if (!TimeInstance)
            TimeInstance = this;
    }
    // Use this for initialization
    void Start()
    {

    }
    public float getFadeTime()
    {
        return Mathf.Round(FadeTime);
    }
    public float getViveTime()
    {
        return Mathf.Round(ViveTime);
    }
    public void RecoveryViveTime()
    {
        ViveTime = 6.0f;
    }
    public float getViveDueTime()
    {
        return Mathf.Round(ViveDueTime);
    }
    public void RecoveryViveDueTime()
    {
        ViveDueTime = 1.5f;
    }
    public float getLimitTime()
    {
        return Mathf.Round(LimitTime);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (LimitTime > 0f)
        {
            hun -= Time.deltaTime * 100;
            if (Mathf.Round(hun) <= 0)
            {
                hun = 99f;
                LimitTime--;
                ViveTime--;

                if (FadeTime >= 0f)
                    FadeTime--;

                if (!HapticsTest.hapticsTest.seatValid)
                    ProgressBarCircle.progressBarCircle.hurtHealth1();
                

            }
            //if (Mathf.Round(LimitTime)==40)
            //{
            //    //Vector3 Fire_Pos = new Vector3(Random.Range(1.5f, 3f), 0.33f, Random.Range(7.7f, 10f));
            //    GameObject Fire = GameObject.Find("Fire_small");
            //    Vector3 Fire_Pos = new Vector3(4.5f, 0.33f, 10.47f);
            //    GameObject new_Fire = (GameObject)Instantiate(Fire, Fire_Pos, Quaternion.identity);
            //}
            text.text = "Time  :" + Mathf.Round(LimitTime)
            + "." + Mathf.Round(hun);
        }
        else
        {
            if (!con)
            {
                text.text = "Time is Over";
                con = true;
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
                Application.LoadLevel("GameOver");
                Time.timeScale = 0;
   
            }

           
            
        }


    }
}
