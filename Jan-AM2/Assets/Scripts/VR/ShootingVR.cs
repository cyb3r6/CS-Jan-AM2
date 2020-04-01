using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingVR : GrabbableObjectVR
{
    public GameObject paintballPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;

    private bool enable;

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
        GameObject tempPaintball = Instantiate(paintballPrefab, spawnPoint.position, spawnPoint.rotation);
        tempPaintball.GetComponent<Rigidbody>().AddForce(tempPaintball.transform.forward * shootingForce);
        Destroy(tempPaintball, 3);
        shotCounterScript.shotsFired++;
    }
}
