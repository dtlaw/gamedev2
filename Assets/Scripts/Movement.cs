using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent( typeof( Rigidbody )) ]
public class Movement : MonoBehaviour {

    // Exposed variables
    [ SerializeField ] private float _movementSpeed;
    [ SerializeField ] private float _rotationSpeed;

    [ Header( "Movement buttons" ) ]
    [ SerializeField ]
    private Control _forwardButton;
    [ SerializeField ]
    private Control _backwardButton;


    // Private variables
    Rigidbody _rigidbody;


    // Messages
    private void Awake() {
        _rigidbody = GetComponent< Rigidbody >();
	}
	
	private void Update() {
        if ( _forwardButton.IsOn()) {
            _rigidbody.AddRelativeForce(Vector3.forward * _movementSpeed);
        } else if ( _backwardButton.IsOn()) {
            _rigidbody.AddRelativeForce(Vector3.back * _movementSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddRelativeForce(Vector3.left * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddRelativeForce(Vector3.right * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.I))
        {
            _rigidbody.AddRelativeTorque(_rotationSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.K))
        {
            _rigidbody.AddRelativeTorque(-_rotationSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.J))
        {
            _rigidbody.AddRelativeTorque(0,0,_rotationSpeed);
        }
        if (Input.GetKey(KeyCode.L))
        {
            _rigidbody.AddRelativeTorque(0,0,-_rotationSpeed);
        }
        if (Input.GetKey(KeyCode.U))
        {
            _rigidbody.AddRelativeTorque(0, -_rotationSpeed,0);
        }
        if (Input.GetKey(KeyCode.O))
        {
            _rigidbody.AddRelativeTorque(0, _rotationSpeed,0);
        }
    }
}
