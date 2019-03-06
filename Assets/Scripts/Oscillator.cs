using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField]
    Vector3 movementVector = new Vector3(10f, 10f, 10f);

    [SerializeField] float period = 2f;

    [Range(0, 1)]
    [SerializeField]
    float movementRange;

    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        //set movement factor authomaticly 
        //protect from devided of 0 (Mathf.Epsilon is the smallest float that we can have)
        if (period <= Mathf.Epsilon)
        {
            return;
        }

        float cycles = Time.time / period; //the cycles that we are going through will grows constantly from 0

        const float tau = Mathf.PI * 2f; //about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // goest from -1 to +1

        movementRange = rawSinWave / 2f + 0.5f; //sicne we need a range between -1 and +1 we have to sum the divided rawSinWave / 2f with 0.5f

        Vector3 offset = movementVector * movementRange;
        transform.position = startingPos + offset;
    }
}
