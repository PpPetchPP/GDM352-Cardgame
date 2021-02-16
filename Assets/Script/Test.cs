using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    GameObject test;
    GameObject g;
    [SerializeField] Transform scoll;
    void Start()
    {
        test = scoll.GetChild(0).gameObject;
        for (int i = 1; i < 10;i++) 
        {
            g = Instantiate(test, scoll);
        }
        Destroy(test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
