using System.Collections;
using System;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    float originalY;

    public float Strength = .2f; 

    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,originalY + ((float)Math.Sin(Time.time) * Strength),transform.position.z);
    }
}
