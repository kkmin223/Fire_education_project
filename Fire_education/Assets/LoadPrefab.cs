using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefab : MonoBehaviour {
    public GameObject RightController, LeftController, DefaultC, Manager;
    // Use this for initialization
    void Start () {
        GameObject RightController = Instantiate(Resources.Load("RightHandInputControl")) as GameObject;
        GameObject LeftController = Instantiate(Resources.Load("LeftHandInputControl")) as GameObject;
        GameObject DefaultC = Instantiate(Resources.Load("DefaultCursor")) as GameObject;
        GameObject Manager = Instantiate(Resources.Load("InputManager")) as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
