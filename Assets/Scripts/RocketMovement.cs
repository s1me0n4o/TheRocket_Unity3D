using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 upFroce = Vector3.up; // .up is equal to Y axes
    Vector3 leftForce = Vector3.forward; // .forward is equal to Z axes

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessInput();

    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(upFroce);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // We can use the Z axes to rotate around 
            transform.Rotate(-leftForce); 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(leftForce);
        }
    }
}
