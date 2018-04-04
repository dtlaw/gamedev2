using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handBehavior : MonoBehaviour {

	// Exposed variables
	[ SerializeField ]
	private float _dist = 5f;
	
	[ Header( "Arm buttons" ) ]
	[ SerializeField ]
	private Control _armGrab;
	[ SerializeField ]
	private Control _armDrop;


	// Private variables
	private bool _grab;

	private Rigidbody _handBody;
	private Animation _grabbing;
	private Transform _grabbedTransform;

	private bool _interact;
	private bool _pressed;


	// Messages
	private void Start() {
		_handBody = gameObject.GetComponent< Rigidbody >();
		_grab = false;
		_interact = false;
		_pressed = false;
		_grabbing = gameObject.GetComponent< Animation >();
		_grabbedTransform = null;
		_grabbing[ "Take 001" ].speed = -1;
		_grabbing[ "Take 001" ].time = _grabbing[ "Take 001" ].length;
		_grabbing.Play( "Take 001" );
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
				_grabbing[ "Take 001" ].speed = 1;
				_grabbing[ "Take 001" ].time = 0;
				_grabbing.Play( "Take 001" );
				hitInfo.collider.transform.SetParent( gameObject.transform );
				_grabbedTransform = hitInfo.collider.transform;
			} else if ( _grab ) {
				Debug.Log ( "Dropped" );
				_grab = false;
				_grabbing[ "Take 001" ].speed = -1;
				_grabbing[ "Take 001" ].time = _grabbing[ "Take 001" ].length;
				_grabbing.Play( "Take 001" );

				// FIXME:
				_grabbedTransform.parent = null;
				// hitInfo.collider.transform.parent = null;
			}
			_pressed = true;
		} else if ( !_armGrab.IsOn()) {
			_pressed = false;
		}
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
