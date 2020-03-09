using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleport : MonoBehaviour
{
    [Tooltip("The transform we want to teleport")]
    public Transform vrRig;

    private LineRenderer line;
    private bool shouldTeleport;
    private Vector3 hitPosition;
    private VRinput controller;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
