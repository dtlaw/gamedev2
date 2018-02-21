using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent( typeof( Rigidbody )) ]
public class Movement : MonoBehaviour {

	// Exposed variables
	[ Header( "Movement forces" ) ]
	[ SerializeField ]
	private float _translationForce;
	[ SerializeField ]
	private float _pitchTorque;
	[ SerializeField ]
	private float _rollTorque;
	[ SerializeField ]
	private float _yawTorque;

	[ Header( "Movement buttons" ) ]
	[ SerializeField ]
	private Control _forward;
	[ SerializeField ]
	private Control _backward;
	[ SerializeField ]
	private Control _strafeLeft;
	[ SerializeField ]
	private Control _strafeRight;
	[ SerializeField ]
	private Control _moveUp;
	[ SerializeField ]
	private Control _moveDown;

	[ Space ]
	[ SerializeField ]
	private Control _pitchUp;
	[ SerializeField ]
	private Control _pitchDown;
	[ SerializeField ]
	private Control _rollLeft;
	[ SerializeField ]
	private Control _rollRight;
	[ SerializeField ]
	private Control _yawLeft;
	[ SerializeField ]
	private Control _yawRight;
	
	


	// Private variables
	Rigidbody _rigidbody;


	// Messages
	private void Awake() {
		_rigidbody = GetComponent< Rigidbody >();
	}
	
	private void Update() {
		if ( _forward.IsOn()) {
			_rigidbody.AddRelativeForce( Vector3.forward * _translationForce );
		} else if ( _backward.IsOn()) {
			_rigidbody.AddRelativeForce( Vector3.back * _translationForce );
		}

		if ( _strafeLeft.IsOn()) {
			_rigidbody.AddRelativeForce( Vector3.left * _translationForce );
		} else if ( _strafeRight.IsOn()) {
			_rigidbody.AddRelativeForce( Vector3.right * _translationForce );
		}

		if ( _moveUp.IsOn()) {
			_rigidbody.AddRelativeForce( Vector3.up * _translationForce );
		} else if ( _moveDown.IsOn()) {
			_rigidbody.AddRelativeForce( Vector3.down * _translationForce );
		}

		if ( _pitchUp.IsOn()) {
			_rigidbody.AddRelativeTorque( -_pitchTorque, 0, 0 );
		} else if ( _pitchDown.IsOn()) {
			_rigidbody.AddRelativeTorque( _pitchTorque, 0, 0 );
		}

		if ( _rollLeft.IsOn()) {
			_rigidbody.AddRelativeTorque( 0, 0, _rollTorque );
		} else if ( _rollRight.IsOn()) {
			_rigidbody.AddRelativeTorque( 0, 0, -_rollTorque );
		}

		if ( _yawLeft.IsOn()) {
			_rigidbody.AddRelativeTorque( 0, _yawTorque, 0);
		} else if ( _yawRight.IsOn()) {
			_rigidbody.AddRelativeTorque( 0, -_yawTorque, 0 );
		}
	}
}
