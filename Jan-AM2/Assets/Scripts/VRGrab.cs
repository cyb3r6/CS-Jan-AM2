using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    private VRinput controller;

    public GameObject collidingObject;
    public GameObject heldObject;

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

            if (collidingObject)
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
        heldObject.transform.SetParent(this.transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Release()
    {
        Debug.Log("Release!");
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }

}
