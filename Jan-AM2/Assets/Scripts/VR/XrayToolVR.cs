using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XrayToolVR : GrabbableObjectVR
{
    [SerializeField]
    private UnityEvent OnPressedEvent;

    [SerializeField]
    private UnityEvent OnReleaseEvent;

    private bool enable = false;
    private bool toggle = false;

    void Update()
    {
        if (isBeingHeld == true)
        {
            if (controller.triggerValue > 0.5f && !enable)
            {
                enable = true;
                Interactable();
            }
            if (controller.triggerValue < 0.5f && enable)
            {
                enable = false;
            }
        }
    }

    public void Interactable()
    {
        toggle = !toggle;
        if (toggle)
        {
            OnPressedEvent?.Invoke();
        }
        else
        {
            OnReleaseEvent?.Invoke();
        }
    }
}
