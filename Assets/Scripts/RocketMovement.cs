using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 upFroce = Vector3.up; // .up is equal to Y axes
    Vector3 leftForce = Vector3.forward; // .forward is equal to Z axes
    AudioSource rocketSound;

    [SerializeField] float thrust = 200;
    [SerializeField] float upThrust = 2000f;
    //public float thrust = 150f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        PowerAndAudio();
        RocketRotation();
    }

    //MovementUpside and audio
    private void PowerAndAudio()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(upFroce * upThrust);
            rocketSound.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rocketSound.enabled = false;
        }
    }

    //Rotation
    private void RocketRotation()
    {
        rb.freezeRotation = true; // freeze the rotation before taking manual contorl in order to freze the rotation in case we hit something

        float rotationSpeed = thrust * Time.deltaTime;

            if (Input.GetKey(KeyCode.A))
            {
                // We can use the Z axes to rotate around 

                transform.Rotate(-leftForce * rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(leftForce * rotationSpeed);
            }

        rb.freezeRotation = false; //resume physics control of rotation
    }
}
