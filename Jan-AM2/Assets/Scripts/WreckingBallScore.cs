using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WreckingBallScore : MonoBehaviour
{
    public Text canvasText;

    void Update()
    {
        canvasText.text = "Number of cubes killed: " + WreckingBallGameManager.instance.numberofCubesDestroyed.ToString();
    }
}
