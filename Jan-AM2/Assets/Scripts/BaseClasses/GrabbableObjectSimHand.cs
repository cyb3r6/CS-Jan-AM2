using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for interactable objects
/// </summary>

public class GrabbableObjectSimHand : MonoBehaviour
{
    public GameObject hand;
    public bool isBeingHeld;
    public SimHandGrab simHandController;
}
