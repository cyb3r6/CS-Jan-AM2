using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocamotion : MonoBehaviour
{
    public Transform vrRig;
    public Transform director;

   

    private VRinput controller;
    private Vector3 playerForward;
    private Vector3 playerRight;



    void Start()
    {
        controller = GetComponent<VRinput>();
    }


    void Update()
    {
        playerForward = director.forward;
        playerForward.y = 0f;
        playerForward.Normalize();

        playerRight = director.right;
        playerRight.y = 0f;
        playerRight.Normalize();

        vrRig.Translate(playerForward * controller.Thumbstick.y * Time.deltaTime);
        vrRig.Translate(playerRight * controller.Thumbstick.x * Time.deltaTime);
    }
}
