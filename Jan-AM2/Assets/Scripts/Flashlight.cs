using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light spotLight;
    private GrabbableObjectSimHand simHandController;

    void Start()
    {
        spotLight = GetComponentInChildren<Light>();
        simHandController = GetComponent<GrabbableObjectSimHand>();
    }

    
    void Update()
    {

        if(simHandController.isBeingHeld == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interactable();
            }
        }
    }

    public void Interactable()
    {
        spotLight.enabled = !spotLight.enabled;
    }
}
