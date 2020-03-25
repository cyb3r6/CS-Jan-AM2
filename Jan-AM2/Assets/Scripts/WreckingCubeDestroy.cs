using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCubeDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WreckingCube")
        {
            WreckingBallGameManager.instance.CountCubesDestroy();
            //Destroy(other.gameObject);
            other.GetComponent<Renderer>().enabled = false;
        }
    }
}
