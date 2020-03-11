using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRinput : MonoBehaviour
{
    public bool isLeftHand;         // if isLeftHand is true, then the script is attached to the left hand
    public float gripValue;
    public float triggerValue;
    public bool isThumbStickPressed;
    public Vector2 Thumbstick;

    private string gripAxis;        // store the grip values of our controller
    private string triggerAxis;
    private string thumbstickButton;
    private string thumbstickX;
    private string thumbstickY;

    public Vector3 handVelocity;
    private Vector3 previousPosition;

    public Vector3 handAngularVelocity;
    private Vector3 previousAngularRotation;

    //private float thumbstickXValue;
    //private float thumbstickYValue;


    void Awake()
    {
        if (isLeftHand)              // short for isLeftHand == true
        {
            gripAxis = "LeftGrip";
            triggerAxis = "LeftTrigger";
            thumbstickButton = "LeftThumbstickButton";
            thumbstickX = "LeftThumbstickX";
            thumbstickY = "LeftThumbstickY";
        }
        else
        {
            gripAxis = "RightGrip";
            triggerAxis = "RightTrigger";
            thumbstickButton = "RightThumbstickButton";
            thumbstickX = "RightThumbstickX";
            thumbstickY = "RightThumbstickY";
        }
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
        triggerValue = Input.GetAxis(triggerAxis);
        //thumbstickXValue = Input.GetAxis(thumbstickX);
        //thumbstickYValue = Input.GetAxis(thumbstickY);

        // OR: Thumbstick = new Vector2(thumbstickXValue, thumbstickYValue);

        Thumbstick = new Vector2(Input.GetAxis(thumbstickX), Input.GetAxis(thumbstickY));


        if (Input.GetButtonDown(thumbstickButton))
        {
            isThumbStickPressed = true;
            Debug.Log(isThumbStickPressed);
        }
        if (Input.GetButtonUp(thumbstickButton))
        {
            isThumbStickPressed = false;
        }

        

        handVelocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        handAngularVelocity = (this.transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = this.transform.eulerAngles;

        

    }
}
