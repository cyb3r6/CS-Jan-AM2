using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallGameManager : MonoBehaviour
{
    public static WreckingBallGameManager instance;
    public int numberofCubesDestroyed;
    
    void Awake()
    {
        instance = this;
    }

    public void CountCubesDestroy()
    {
        numberofCubesDestroyed = numberofCubesDestroyed + 1;    // or numberofCubesDestroyed++
    }    
}
