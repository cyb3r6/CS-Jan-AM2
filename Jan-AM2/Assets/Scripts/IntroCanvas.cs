using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCanvas : MonoBehaviour
{
    public void LaunchVRScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
