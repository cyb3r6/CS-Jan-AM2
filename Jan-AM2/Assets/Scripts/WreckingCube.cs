using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCube : MonoBehaviour
{
    public WreckingBallResetButton resetButton;

    Vector3 startPosition;
    Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        resetButton.OnButtonPressed += ResetCube;
    }

    public void ResetCube()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        // reset score
        WreckingBallGameManager.instance.numberofCubesDestroyed = 0;

        // show the cube
        GetComponent<Renderer>().enabled = true;

        // stop it's movement!
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
