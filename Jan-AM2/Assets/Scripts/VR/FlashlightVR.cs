using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightVR : GrabbableObjectVR
{
    private Light spotLight;
    private bool enable = false;

    void Start()
    {
        spotLight = GetComponentInChildren<Light>();
    }

    
    void Update()
    {
        if (isBeingHeld == true)
        {
            if (controller.triggerValue > 0.5f && !enable)
            {
                enable = true;
                Interactable();
            }
            if(controller.triggerValue < 0.5f && enable)
            {
                enable = false;
            }
        }
    }

    public void Interactable()
    {
        spotLight.enabled = !spotLight.enabled;
    }
}
