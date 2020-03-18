using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringButton : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpringButton")
        {
            // do something!
        }
    }
}
