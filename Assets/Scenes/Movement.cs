using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * 0.5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.back * 0.5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(Vector3.left * 0.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.right * 0.5f);
        }
        if (Input.GetKey(KeyCode.I))
        {
            rb.AddRelativeTorque(0.1f,0,0);
        }
        if (Input.GetKey(KeyCode.K))
        {
            rb.AddRelativeTorque(-0.1f,0,0);
        }
        if (Input.GetKey(KeyCode.J))
        {
            rb.AddRelativeTorque(0,0,-0.1f);
        }
        if (Input.GetKey(KeyCode.L))
        {
            rb.AddRelativeTorque(0,0,0.1f);
        }
        if (Input.GetKey(KeyCode.U))
        {
            rb.AddRelativeTorque(0, -0.1f,0);
        }
        if (Input.GetKey(KeyCode.O))
        {
            rb.AddRelativeTorque(0, 0.1f,0);
        }
    }
}
