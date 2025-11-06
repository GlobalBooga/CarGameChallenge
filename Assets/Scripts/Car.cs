using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 1;
    
    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.down * (Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Reset"))
        {
            gameObject.SetActive(false);
        }
    }
}
