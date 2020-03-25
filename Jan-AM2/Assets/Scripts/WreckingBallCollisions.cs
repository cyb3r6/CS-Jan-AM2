using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallCollisions : MonoBehaviour
{
    public GameObject bigFrank;
    public GameObject miniFranks;
    public int numberofCollisions = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 1)
        {
            numberofCollisions--;
            if(numberofCollisions == 0)
            {
                bigFrank.SetActive(false);
                miniFranks.SetActive(true);
            }            
        }
    }
}
