using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public GameObject collidingObject;
    public GameObject heldObject;
    public float throwForce;
    public Transform grabPosition;
    private MovementJan movementJan;

    private void Awake()
    {
        movementJan = GetComponent<MovementJan>();
    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        // check that we exited the colling object and not just some other object
        if(other.gameObject == collidingObject)
        {
            collidingObject = null;
        }        
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;

                Grab();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
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

    public void Grab()
    {
        Debug.Log("Grabbed!");
        heldObject.transform.SetParent(grabPosition);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        #region Using GetComponent method

        var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
        }

        #endregion
    }

    public void Release()
    {
        Debug.Log("Release!");

        #region Using GetComponent method

        var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
        if (grabbable)
        {
            grabbable.hand = null;
            grabbable.isBeingHeld = false;
        }

        #endregion

        heldObject.GetComponent<Rigidbody>().velocity = movementJan.handVelocity * throwForce;
        heldObject.GetComponent<Rigidbody>().angularVelocity = movementJan.handAngularVelocity * throwForce;
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

        var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
        }
    }

    public void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
            if (grabbable)
            {
                grabbable.hand = null;
                grabbable.isBeingHeld = false;
            }

            Destroy(GetComponent<FixedJoint>());
            heldObject.GetComponent<Rigidbody>().velocity = movementJan.handVelocity * throwForce;
            heldObject.GetComponent<Rigidbody>().angularVelocity = movementJan.handAngularVelocity * throwForce;
            heldObject = null;
        }
    }
}
