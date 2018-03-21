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

	[ SerializeField ]
	private GameObject _shoulder;
	[ SerializeField ]
	private GameObject _forearm;
	[ SerializeField ]
	private GameObject _wrist;
	[ SerializeField ]
	private GameObject _hand;

	private Rigidbody _shoulderbody;
	private Rigidbody _forearmbody;
	private Rigidbody _handbody;
	private Rigidbody _wristbody;

	// Private variables
	Rigidbody _rigidbody;


	// Messages
	private void Awake() {
		_rigidbody = GetComponent< Rigidbody >();
		_shoulderbody = _shoulder.GetComponent<Rigidbody>();
		_forearmbody = _forearm.GetComponent<Rigidbody>();
		_handbody = _hand.GetComponent<Rigidbody>();
		_wristbody = _wrist.GetComponent<Rigidbody>();
	}

	private void Update() {
		if(_shoulder.GetComponent<shoulderBehavior>().use == false &&
			_forearm.GetComponent<forearmBehavior>().use == false && 
			_wrist.GetComponent<wristBehavior>().use == false){
			_shoulderbody.constraints = RigidbodyConstraints.FreezePosition;
			_forearmbody.constraints = RigidbodyConstraints.FreezePosition;
			_handbody.constraints = RigidbodyConstraints.FreezePosition;
			_wristbody.constraints = RigidbodyConstraints.FreezePosition;
		}else{
			_shoulderbody.constraints = RigidbodyConstraints.None;
			_forearmbody.constraints = RigidbodyConstraints.None;
			_handbody.constraints = RigidbodyConstraints.None;
			_wristbody.constraints = RigidbodyConstraints.None;
		}
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
			_rigidbody.AddRelativeTorque( 0, -_yawTorque, 0);
		} else if ( _yawRight.IsOn()) {
			_rigidbody.AddRelativeTorque( 0, _yawTorque, 0 );
		}
	}
}
