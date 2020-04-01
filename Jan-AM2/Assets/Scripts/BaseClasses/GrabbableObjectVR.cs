using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for VR interactable objects
/// </summary>


public class GrabbableObjectVR : MonoBehaviour
{
    public GameObject hand;
    public bool isBeingHeld;
    public VRinput controller;
}
