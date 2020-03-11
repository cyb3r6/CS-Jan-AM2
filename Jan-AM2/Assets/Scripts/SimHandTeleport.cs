using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandTeleport : MonoBehaviour
{
    [Tooltip("The transform we want to teleport")]
    public Transform simHand;

    private LineRenderer line;
    private MovementJan movementJan;
    private bool shouldTeleport;
    private Vector3 hitPosition;

    private float offset;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        movementJan = GetComponent<MovementJan>();
    }

    
    void Update()
    {
        if (movementJan.isButtonPressed)
        {
            RaycastHit hit;
            if(Physics.Raycast(simHand.position, simHand.forward, out hit))
            {
                hitPosition = hit.point;
                line.SetPosition(0, simHand.position);
                line.SetPosition(1, hitPosition);

                shouldTeleport = true;

                line.enabled = true;

                Offset();
            }
        }
        else if(movementJan.isButtonPressed == false)
        {
            if(shouldTeleport == true)
            {
                simHand.position = new Vector3(hitPosition.x, hitPosition.y + offset, hitPosition.z);
                shouldTeleport = false;
                line.enabled = false;
            }
        }
    }

    private float Offset()
    {
        RaycastHit offsetHit;
        if(Physics.Raycast(simHand.position, -simHand.up, out offsetHit))
        {
            Vector3 distance = simHand.position - offsetHit.point;

            return offset = distance.y;
        }
        else
        {
            return default;     // default value of a float = 0.0f. bool = false. string = null.
        }
    }
}
