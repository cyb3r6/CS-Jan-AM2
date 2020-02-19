using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject paintballPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject tempPaintball = Instantiate(paintballPrefab, spawnPoint.position, spawnPoint.rotation);
            tempPaintball.GetComponent<Rigidbody>().AddForce(tempPaintball.transform.forward * shootingForce);
            Destroy(tempPaintball, 3);
            shotCounterScript.shotsFired++;
        }
    }
}
