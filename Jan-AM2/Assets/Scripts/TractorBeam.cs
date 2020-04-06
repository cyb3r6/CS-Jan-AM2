using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : GrabbableObjectSimHand
{
    public Transform startPoint;
    private LineRenderer tractorBeam;
    private RaycastHit hit;
    private Transform hitTransform;
    private Rigidbody hitRigidbody;
    

    void Start()
    {
        tractorBeam = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        if (isBeingHeld == true)
        {
            if (simHandController.isButtonPressed)
            {
                Interactable();
            }
            else
            {
                Drop();
            }
        }
    }

    private void Interactable()
    {
        if(Physics.Raycast(startPoint.position, transform.forward, out hit))
        {
            hitTransform = hit.transform;
            tractorBeam.enabled = true;
            tractorBeam.SetPosition(0, startPoint.position);
            tractorBeam.SetPosition(1, hit.point);
            hitRigidbody = hitTransform.GetComponent<Rigidbody>();

            if(hitRigidbody && !hitRigidbody.isKinematic)
            {
                hitRigidbody.useGravity = false;

                // move the hitTransform toward us!
                hitTransform.position = Vector3.Lerp(hitTransform.position, startPoint.position, Time.deltaTime);
            }
            else
            {
                hitTransform = null;
            }
        }
        else
        {
            Drop();
        }
    }

    private void Drop()
    {
        tractorBeam.enabled = false;
        if (hitTransform)
        {
            hitRigidbody.useGravity = true;
            hitTransform = null;
            hitRigidbody = null;
        }
    }
}
