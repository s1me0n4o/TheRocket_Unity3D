using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRocket : MonoBehaviour
{

    [SerializeField] Transform rocket;
    [SerializeField] Vector3 offset;

    void FixedUpdate()
    {
        transform.position = rocket.position + offset;
    }
}
