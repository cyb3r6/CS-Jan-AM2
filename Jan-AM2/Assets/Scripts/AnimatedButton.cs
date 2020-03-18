using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedButton : MonoBehaviour
{
    public Animator buttonAnim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonAnim.SetTrigger("Press");

            // do something here too!
        }
    }
    
}
