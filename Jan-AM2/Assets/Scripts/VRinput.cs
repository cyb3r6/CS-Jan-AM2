using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRinput : MonoBehaviour
{
    public bool isLeftHand;         // if isLeftHand is true, then the script is attached to the left hand
    public float gripValue;
    public float triggerValue;

    private string gripAxis;        // store the grip values of our controller

    void Awake()
    {
        if (isLeftHand)              // short for isLeftHand == true
        {
            gripAxis = "LeftGrip";
        }
        else
        {
            gripAxis = "RightGrip";
        }

    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
    }
}
