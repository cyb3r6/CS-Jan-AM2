using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    public int shotsFired;
    public Text canvasText;

    // check how many shots have been fired
    // print that to the text
    void Update()
    {
        canvasText.text = "Shots fired is: " + shotsFired;
    }
}
