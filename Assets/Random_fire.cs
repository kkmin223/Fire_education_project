using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_fire : MonoBehaviour {

    // Use this for initialization
    GameObject Fire = GameObject.Find("Fire_small");
    private float TimeLeft = 4.0f;
    private float nextTime = 0.0f;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            make_fire();
        }     
    }
    void make_fire()
    {
        
    }
}
