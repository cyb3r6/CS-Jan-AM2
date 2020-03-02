using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimator : MonoBehaviour
{
    private Animator vrHandAnimator;
    private VRinput controller;

   
    void Awake()
    {
        vrHandAnimator = GetComponentInChildren<Animator>();
        controller = GetComponent<VRinput>();
    }

    
    void Update()
    {
        if (controller)
        {
            if (vrHandAnimator)
            {
                vrHandAnimator.Play("Fist Closing", 0, controller.gripValue);
            }
        }
    }
}
