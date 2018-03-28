using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handBehavior : MonoBehaviour {

	// Exposed variables
	[ SerializeField ]
	private int _muscleForce = 500;
	[ SerializeField ]
	private float _dist = 5f;
	
	[ Header( "Arm buttons" ) ]
	[ SerializeField ]
	private Control _armGrab;
	[ SerializeField ]
	private Control _armDrop;


	// Private variables
	private bool _grab;

	private HingeJoint _hand;
	private JointMotor _muscle;
	private Rigidbody _handBody;
	private Animation _grabbing;
	private Transform _grabbedTransform;

	private bool _interact;
	private bool _pressed;


	// Messages
	private void Start() {
		_hand = gameObject.GetComponent< HingeJoint >();
		_handBody = gameObject.GetComponent< Rigidbody >();
		_muscle = _hand.motor;
		_grab = false;
		_interact = false;
		_pressed = false;
		_grabbing = gameObject.GetComponent< Animation >();
		_grabbedTransform = null;
	}
	
	private void Update() {
		Ray ray = new Ray ( this.transform.position, this.transform.up );
		Debug.DrawRay( this.transform.position, this.transform.up * _dist );

		RaycastHit hitInfo;
		if (( Physics.Raycast( ray, out hitInfo, _dist ) && hitInfo.collider.tag == "interactable" ) || _grab ) {
			_interact = true;
		} else {
			_interact = false;
		}

		if ( _armGrab.IsOn() && !_pressed ) {
			if( !_grab && Physics.Raycast( ray, out hitInfo, _dist ) && hitInfo.collider.tag == "interactable" ){
				Debug.Log( "Grabbed" );
				_grab = true;
				_grabbing[ "grab" ].speed = 1;
				_grabbing[ "grab" ].time = 0;
				_grabbing.Play( "grab" );
				hitInfo.collider.transform.SetParent( gameObject.transform );
				_grabbedTransform = hitInfo.collider.transform;
			} else if ( _grab ) {
				Debug.Log ( "Dropped" );
				_grab = false;
				_grabbing[ "grab" ].speed = -1;
				_grabbing[ "grab" ].time = _grabbing[ "grab" ].length;
				_grabbing.Play( "grab" );

				// FIXME:
				_grabbedTransform.parent = null;
				// hitInfo.collider.transform.parent = null;
			}
			_pressed = true;
		} else if ( !_armGrab.IsOn()) {
			_pressed = false;
		}

		if ( _armDrop.IsOn()) {
			_hand.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = _muscleForce;
		} else {
			_hand.useMotor = false;
			_muscle.force = 0;
		}
		_hand.motor = _muscle;
		_handBody.velocity = Vector3.zero;
		_handBody.angularVelocity = Vector3.zero;
	}


	// Public interface
	public bool Grab() {
		return _grab;
	}

	public bool Interact() {
		return _interact;
	}

	public void setGrabFalse() {
		_grab = false;
		_grabbedTransform.parent = null;
	}
}
