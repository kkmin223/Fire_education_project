using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDC : MonoBehaviour {

    public static DestroyDC DesInstance;
    // Use this for initialization
    void Awake()
    {

            DesInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DesDC()
    {
        Destroy(gameObject);
    }
}
