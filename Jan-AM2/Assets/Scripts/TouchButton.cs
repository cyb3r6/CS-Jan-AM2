using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TouchButton : MonoBehaviour
{
    public Transform downPosition, upPosition, buttonTransform;
    public VideoPlayer videoCube;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonTransform.position = downPosition.position;
            videoCube.Play();
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
