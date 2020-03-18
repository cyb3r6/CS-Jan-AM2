using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    private VRinput controller;

    public GameObject collidingObject;
    public GameObject heldObject;
    public float throwForce;
    public Transform grabPosition;

    private bool gripHeld;      // prevent the Grab(); from being called every frame

    void Awake()
    {
        controller = GetComponent<VRinput>();
    }

    
    void Update()
    {
        if (controller.gripValue > 0.8f && gripHeld == false)
        {
            gripHeld = true;

            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;

                Grab();
            }
        }
        else if(controller.gripValue < 0.8f && gripHeld == true)
        {
            gripHeld = false;

            if (heldObject)
            {
                Release();
            }
        }

        #region Using BroadcastMessage
        /*
        if(Input.GetKeyDown(KeyCode.Mouse0) && heldObject)
        {
            heldObject.BroadcastMessage("Interactable");
        }
        */
        #endregion

    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        // check that we exited the colling object and not just some other object
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }        
    }

    public void Grab()
    {
        Debug.Log("Grabbed!");
        heldObject.transform.SetParent(grabPosition);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        #region Using GetComponent method

        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.controller = controller;
        }

        #endregion
    }

    public void Release()
    {
        Debug.Log("Release!");

        #region Using GetComponent method

        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.hand = null;
            grabbable.isBeingHeld = false;
            grabbable.controller = null;
        }

        #endregion

        heldObject.GetComponent<Rigidbody>().velocity = controller.handVelocity * throwForce;
        heldObject.GetComponent<Rigidbody>().angularVelocity = controller.handAngularVelocity * throwForce;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }

    public void AdvGrab()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 2000;
        heldObject.transform.rotation = this.transform.rotation;
        fx.connectedBody = heldObject.GetComponent<Rigidbody>();

        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.controller = controller;
        }
    }

    public void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
            if (grabbable)
            {
                grabbable.hand = null;
                grabbable.isBeingHeld = false;
                grabbable.controller = null;
            }

            Destroy(GetComponent<FixedJoint>());
            heldObject.GetComponent<Rigidbody>().velocity = controller.handVelocity * throwForce;
            heldObject.GetComponent<Rigidbody>().angularVelocity = controller.handAngularVelocity * throwForce;
            heldObject = null;
        }
    }

}
