using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallLine : MonoBehaviour
{
    public Transform wreckingBall, wreckingCube;
    public LineRenderer chain;

    void Update()
    {
        chain.SetPosition(0, wreckingBall.position);
        chain.SetPosition(1, wreckingCube.position);
    }
}
