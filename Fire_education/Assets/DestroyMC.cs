using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMC : MonoBehaviour
{

    public static DestroyMC DesInstance;
    // Use this for initialization
    void Awake()
    {

            DesInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DesMC()
    {
        Destroy(gameObject);
    }
}
