using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeLever : MonoBehaviour
{
    private HingeJoint myJoint;
    
    void Start()
    {
        myJoint = GetComponent<HingeJoint>();
    }
    
    public float JointAngle()
    {
        float angle = myJoint.angle/myJoint.limits.max;

        return angle;
    }
}
