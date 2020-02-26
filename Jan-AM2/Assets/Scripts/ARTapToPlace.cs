using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject objectToInstantiate;                          // is the prefab we'll use
    static GameObject spawnedObject;                                // the reference to the object we instantiate

    private ARRaycastManager arRaycastmanager;

    private Vector2 touchPosition;                                  // store the position of our finger on the screen

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();      // store our hits

    
    void Start()
    {
        arRaycastmanager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        // the position of the finger on the screen
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;

            // if all of that happens above, return and exit the function 
            return true;
        }

        touchPosition = default;
        return false;
    }


    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if(arRaycastmanager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance
            // the first hit[0] will be the closets one
            var hitPose = hits[0].pose;

            spawnedObject = Instantiate(objectToInstantiate, hitPose.position, hitPose.rotation);
        }
    }

    
}
