using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.back * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(Vector3.left * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.I))
        {
            rb.AddRelativeTorque(rotationSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.K))
        {
            rb.AddRelativeTorque(-rotationSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.J))
        {
            rb.AddRelativeTorque(0,0,rotationSpeed);
        }
        if (Input.GetKey(KeyCode.L))
        {
            rb.AddRelativeTorque(0,0,-rotationSpeed);
        }
        if (Input.GetKey(KeyCode.U))
        {
            rb.AddRelativeTorque(0, -rotationSpeed,0);
        }
        if (Input.GetKey(KeyCode.O))
        {
            rb.AddRelativeTorque(0, rotationSpeed,0);
        }
    }
}
