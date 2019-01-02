using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_fire : MonoBehaviour {
    public static Destroy_fire ext;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void destroy_firewall()
    {
        Destroy(this, 5);
    }
}
