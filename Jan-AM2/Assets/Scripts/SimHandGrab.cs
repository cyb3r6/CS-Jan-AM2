using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public GameObject collidingObject;
    public GameObject heldObject;
    public float throwForce;
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
            if (collidingObject)
            {
                heldObject = collidingObject;

                AdvGrab();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (heldObject)
            {
                AdvRelease();
            }
        }
    }

    public void Grab()
    {
        Debug.Log("Grabbed!");
        heldObject.transform.SetParent(this.transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Release()
    {
        Debug.Log("Release!");
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
    }

    public void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            Destroy(GetComponent<FixedJoint>());
            heldObject.GetComponent<Rigidbody>().velocity = movementJan.handVelocity * throwForce;
            heldObject.GetComponent<Rigidbody>().angularVelocity = movementJan.handAngularVelocity * throwForce;
            heldObject = null;
        }
    }
}
