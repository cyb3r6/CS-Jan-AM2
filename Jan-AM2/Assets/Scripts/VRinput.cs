using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRinput : MonoBehaviour
{
    public bool isLeftHand;         // if isLeftHand is true, then the script is attached to the left hand
    public float gripValue;
    public float triggerValue;
    public bool isThumbStickPressed;

    private string gripAxis;        // store the grip values of our controller
    private string triggerAxis;
    private string thumbstickButton;

    void Awake()
    {
        if (isLeftHand)              // short for isLeftHand == true
        {
            gripAxis = "LeftGrip";
            triggerAxis = "LeftTrigger";
            thumbstickButton = "LeftThumbstickButton";
        }
        else
        {
            gripAxis = "RightGrip";
            triggerAxis = "RightTrigger";
            thumbstickButton = "RightThumbstickButton";
        }
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
        triggerValue = Input.GetAxis(triggerAxis);

        if (Input.GetButtonDown(thumbstickButton))
        {
            isThumbStickPressed = true;
        }
        if (Input.GetButtonDown(thumbstickButton))
        {
            isThumbStickPressed = false;
        }
    }
}
