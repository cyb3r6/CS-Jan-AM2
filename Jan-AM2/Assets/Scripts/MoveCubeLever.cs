using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeLever : MonoBehaviour
{
    public HingeLever forwardBackLeverController, rightLeftLeverController;
    public float speed;

    void Update()
    {
        
        transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardBackLeverController.JointAngle();

        transform.position = transform.position + transform.right * Time.deltaTime * speed * rightLeftLeverController.JointAngle();
    }
}
