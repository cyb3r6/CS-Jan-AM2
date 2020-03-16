using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : GrabbableObjectSimHand
{
    public GameObject paintballPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;

    //private GrabbableObjectSimHand gosimHandController;

    private void Start()
    {
        //gosimHandController = GetComponent<GrabbableObjectSimHand>();
    }

    private void Update()
    {
        if (isBeingHeld == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interactable();
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
