using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIM : MonoBehaviour
{
    public static DestroyIM DesInstance;
    // Use this for initialization
    void Awake()
    {
   
            DesInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DesIM()
    {
        Destroy(gameObject);
    }


}
