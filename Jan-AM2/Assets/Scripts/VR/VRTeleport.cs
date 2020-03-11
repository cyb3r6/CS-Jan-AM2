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


    void Awake()
    {
        controller = this.GetComponent<VRinput>();
        line = this.GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        if (controller.isThumbStickPressed)
        {
            RaycastHit hit;
            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
            {
                hitPosition = hit.point;
                line.SetPosition(0, controller.transform.position);
                line.SetPosition(1, hitPosition);

                shouldTeleport = true;

                line.enabled = true;

                
            }
        }
        else if (controller.isThumbStickPressed == false)
        {
            if (shouldTeleport == true)
            {
                vrRig.transform.position = hitPosition;
                shouldTeleport = false;
                line.enabled = false;
            }
        }
    }
}
