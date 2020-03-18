using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightVR : GrabbableObjectVR
{
    private Light spotLight;

    void Start()
    {
        spotLight = GetComponentInChildren<Light>();
    }

    
    void Update()
    {
        if (isBeingHeld == true)
        {
            if (controller.triggerValue > 0.5f)
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
