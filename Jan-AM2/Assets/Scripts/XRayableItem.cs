using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will be attached to a gameobject
/// in the heiarchy that we want to xray
/// </summary>
public class XRayableItem : MonoBehaviour
{
    private int startingRenderQueue;
    public List<Renderer> treasureRenderers = new List<Renderer>();

    void Start()
    {
        startingRenderQueue = treasureRenderers[0].material.renderQueue;
    }
    
    public void XRay()
    {
        foreach(Renderer rend in treasureRenderers)
        {
            rend.material.renderQueue = 3002;
        }
    }
    public void DeXRay()
    {
        foreach (Renderer rend in treasureRenderers)
        {
            rend.material.renderQueue = startingRenderQueue;
        }
    }
}
