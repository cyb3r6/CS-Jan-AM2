using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will be attached to a gameobject
/// in the heiarchy that we want to xray
/// </summary>
public class XRayableItem : MonoBehaviour
{
    
    void Start()
    {
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.renderQueue = 3002;
        }
    }
    
}
