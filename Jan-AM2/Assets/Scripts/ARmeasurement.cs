using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ARmeasurement : MonoBehaviour
{
    public GameObject measurementPointPrefab;

    public Vector3 textoffsetmeasurement = Vector3.zero;

    public TextMeshProUGUI distanceText;

    public ARCameraManager arCameraManager;

    public float measurementFactor = 39.4f;

    private ARRaycastManager arRaycastManager;
    private LineRenderer measurementLine;
    private GameObject startPoint;
    private GameObject endPoint;
    private Vector2 touchPosition;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        measurementLine = GetComponent<LineRenderer>();

        startPoint = Instantiate(measurementPointPrefab, Vector3.zero, Quaternion.identity);
        endPoint = Instantiate(measurementPointPrefab, Vector3.zero, Quaternion.identity);
        startPoint.SetActive(false);
        endPoint.SetActive(true);
    }

    
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                touchPosition = touch.position;

                if(arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    startPoint.SetActive(true);
                    Pose hitPose = hits[0].pose;
                    startPoint.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
                }
            }
            // if the user is moving their finger
            if(touch.phase == TouchPhase.Moved)
            {
                touchPosition = touch.position;

                if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    measurementLine.gameObject.SetActive(true);
                    endPoint.SetActive(true);
                    Pose hitPose = hits[0].pose;
                    endPoint.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
                }
            }
        }

        if(startPoint.activeSelf && endPoint.activeSelf)
        {
            distanceText.transform.position = endPoint.transform.position + textoffsetmeasurement;
            distanceText.transform.rotation = endPoint.transform.rotation;
            measurementLine.SetPosition(0, startPoint.transform.position);
            measurementLine.SetPosition(1, endPoint.transform.position);

            distanceText.text = "Distance is: " + ((Vector3.Distance(startPoint.transform.position, endPoint.transform.position)) / measurementFactor).ToString() + "inches";
        }
    }

}
