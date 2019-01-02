using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLIC : MonoBehaviour {

    public static DestroyLIC DesInstance;
    // Use this for initialization
    void Awake()
    {
    
            DesInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DesLIC()
    {
        Destroy(gameObject);
    }
}
