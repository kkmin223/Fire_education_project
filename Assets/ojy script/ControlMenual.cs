using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlMenual : MonoBehaviour {

    public static ControlMenual instance;
    public Text messageText;
    private string menualMesssage;
    // Use this for initialization

    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Menual_1()
    {
        menualMesssage = "핸드폰을 이용해 화재를 신고하자!";
        messageText.text = menualMesssage;
    }
    public void Menual_2()
    {
        menualMesssage = "전원차단기를 내리자!";
        messageText.text = menualMesssage;
    }
    public void Menual_3()
    {
        menualMesssage = "수건을 가지고 화장실로 가자!";
        messageText.text = menualMesssage;
    }
    public void Menual_4()
    {
        menualMesssage = "수건을 물로 적시자!";
        messageText.text = menualMesssage;
    }
    public void Menual_5()
    {
        menualMesssage = "소화기를 이용해 불을 끄자!";
        messageText.text = menualMesssage;
    }
    public void Menual_6()
    {
        menualMesssage = "집에서 탈출하여 화재 비상벨을 울리자!";
        messageText.text = menualMesssage;
    }
    public void Menual_7()
    {
        menualMesssage = "계단을 이용해 탈출하자!";
        messageText.text = menualMesssage;
    }
}
