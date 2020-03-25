using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeLever : MonoBehaviour
{
    public HingeLever forwardBackLeverController, rightLeftLeverController, upDownLeverController;
    public float speed;

    void Update()
    {
        if(Mathf.Abs(forwardBackLeverController.JointAngle()) > 0.05f)
            transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardBackLeverController.JointAngle();

        if (Mathf.Abs(rightLeftLeverController.JointAngle()) > 0.05f)
            transform.position = transform.position + transform.right * Time.deltaTime * speed * rightLeftLeverController.JointAngle();

        if (Mathf.Abs(upDownLeverController.JointAngle()) > 0.05f)
            transform.position = transform.position + transform.up * Time.deltaTime * speed * upDownLeverController.JointAngle();
    }
}
