using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Friendly"))// || Fluel == 0)
        {
            print("Game Over");
            //destroy rocket
            //reload the level after 2 secs
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            print("You Win");
        }
                
    }

}
