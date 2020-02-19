using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerzone : MonoBehaviour
{
    public Animator bridgeAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bridgeAnimator.SetTrigger("RaiseBridge");
        }
    }
}
