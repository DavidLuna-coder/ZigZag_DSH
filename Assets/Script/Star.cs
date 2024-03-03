using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed=1.0f;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(Vector3.up, speed , Space.World);
    }
}
