using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

        
    }

    
    // Update is called once per frame
    private void Update()
    {
        
        transform.position += Vector3.down * (Time.deltaTime * speed);
    }
}
