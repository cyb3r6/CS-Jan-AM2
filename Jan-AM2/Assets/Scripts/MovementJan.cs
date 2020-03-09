using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJan : MonoBehaviour
{
    public Transform location;
    public float jumpForce;
    public float movementSpeed;
    public float turnSpeed;

    public Vector3 handVelocity;
    private Vector3 previousPosition;

    public Vector3 handAngularVelocity;
    private Vector3 previousAngularRotation;

    public bool isButtonPressed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        #region Translational Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);

            //Rigidbody rb = GetComponent<Rigidbody>();
            //rb.AddForce(Vector3.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.T))
        {
            isButtonPressed = true;
        }
        else
        {
            isButtonPressed = false;
        }

        #endregion

        #region Rotation using the keyboard
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        //}
        //if (Input.GetKey(KeyCode.Q) * Time.deltaTime * turnSpeed)
        //{
        //    transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
        //}
        //if (Input.GetKey(KeyCode.C))
        //{
        //    transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed);
        //}
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed);
        //}
        #endregion

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X"), Space.World);
        transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y"), Space.World);


        handVelocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        handAngularVelocity = (this.transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = this.transform.eulerAngles;


    }

}
