using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJan : MonoBehaviour
{
    public Transform location;
    public float jumpForce;
    public float movementSpeed;
    public float turnSpeed;
    
    void Start()
    {
        
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.Translate(Vector3.up);

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpForce);
        }
        #endregion

        #region Rotation using the keyboard
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.Rotate(Vector3.up);
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.Rotate(Vector3.down);
        //}
        //if (Input.GetKey(KeyCode.U))
        //{
        //    transform.Rotate(Vector3.right);
        //}
        #endregion

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed);
    }

}
