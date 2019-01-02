using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class exitButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void RetryButton() {
     
        Time_count.TimeInstance.LimitTime = 60f;
        //DestroyIM.DesInstance.DesIM();
        //Destroy(gameObject);
        SceneManager.LoadScene("SampleScene");


    }
}
