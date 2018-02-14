using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //Editor Variables
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    //Private Variables
    Rigidbody _rb;

    // Just to get RB
    private void Awake () {
        _rb = this.GetComponent<Rigidbody>();
	}
	
	private void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddRelativeForce(Vector3.forward * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddRelativeForce(Vector3.back * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddRelativeForce(Vector3.left * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddRelativeForce(Vector3.right * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.I))
        {
            _rb.AddRelativeTorque(_rotationSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.K))
        {
            _rb.AddRelativeTorque(-_rotationSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.J))
        {
            _rb.AddRelativeTorque(0,0,_rotationSpeed);
        }
        if (Input.GetKey(KeyCode.L))
        {
            _rb.AddRelativeTorque(0,0,-_rotationSpeed);
        }
        if (Input.GetKey(KeyCode.U))
        {
            _rb.AddRelativeTorque(0, -_rotationSpeed,0);
        }
        if (Input.GetKey(KeyCode.O))
        {
            _rb.AddRelativeTorque(0, _rotationSpeed,0);
        }
    }
}
