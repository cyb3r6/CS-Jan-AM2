using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WreckingBallResetButton : MonoBehaviour
{
    public Transform downPosition, upPosition, buttonTransform;

    public delegate void ButtonPressedEvent();  // subscribing methods to this variable
    public ButtonPressedEvent OnButtonPressed;  // an instance of the ButtonPressedEvent()

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonTransform.position = downPosition.position;
            OnButtonPressed();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonTransform.position = upPosition.position;
        }
    }
    
}
