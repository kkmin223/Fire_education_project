using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFQ : MonoBehaviour {

    public static DestroyFQ DesInstance;
    // Use this for initialization
    void Awake()
    {
    
         DesInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DesFQ()
    {
        Destroy(this.gameObject);
    }
}
