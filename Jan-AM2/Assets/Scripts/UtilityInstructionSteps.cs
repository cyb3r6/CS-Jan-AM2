using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityInstructionSteps : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject initializeHeatCanvas;
    public GameObject saltWaterCanvas;

    private List<GameObject> steps = new List<GameObject>();
    private int currentStep = 0;
    private GameObject currentCanvas;

    public void TurnOnInitializeHeatCanvas()
    {
        mainMenuCanvas.SetActive(false);
        initializeHeatCanvas.SetActive(true);

        steps.Clear();

        for(int i = 0; i < initializeHeatCanvas.transform.childCount - 1; i++)
        {
            steps.Add(initializeHeatCanvas.transform.GetChild(i).gameObject);
        }
        currentCanvas = initializeHeatCanvas;
    }

    public void TurnOnSaltWaterCanvas()
    {
        mainMenuCanvas.SetActive(false);
        saltWaterCanvas.SetActive(true);

        steps.Clear();

        for (int i = 0; i < saltWaterCanvas.transform.childCount - 1; i++)
        {
            steps.Add(saltWaterCanvas.transform.GetChild(i).gameObject);
        }
        currentCanvas = saltWaterCanvas;
    }

    public void NextStep()
    {
        steps[currentStep].SetActive(false);

        if(currentStep == steps.Count - 1)
        {
            currentStep = 0;
            steps[0].SetActive(true);
            currentCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);

            return;
        }

        // check!

        steps[++currentStep].SetActive(true);
    }

    public void PreviousStep()
    {

    }

}
