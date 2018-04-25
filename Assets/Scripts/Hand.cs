﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

	// Exposed variables
	[ SerializeField ]
	private Control _grabButton;
	[ SerializeField ]
	private float _grabDistance;
	[ SerializeField ]
	private string _grabStateName;
	[ SerializeField ]
	private Transform _grabPosition;

	[ SerializeField ]
	private GameObject _forearm;
	private jointMotor _forearmJoint;
	[ SerializeField ]
	private GameObject _upperarm;
	private jointMotor _upperarmJoint;
	public Quaternion currentRot;
	private bool _released;

	// Public variables
	private GameObject _canInteract;
	public GameObject CanInteract { get { return _canInteract; }}


	// Private variables
	private Transform _transform;
	private Animator _animator;
	private Rigidbody _rigidbody;

	private Transform _grabbedTransform;
	private bool _grabbing;
	private bool _switch;
	private bool _position;

	public bool Grabbing { get { return _grabbing; }}


	// Messages
	private void Awake() {
		_transform = GetComponent< Transform >();
		_rigidbody = GetComponent< Rigidbody >();
		_animator = GetComponent< Animator >();

		_upperarmJoint = _upperarm.GetComponent<jointMotor>();
		_forearmJoint = _forearm.GetComponent<jointMotor>();
		currentRot = gameObject.transform.localRotation;
		_released = false;
		_grabbing = false;
		_switch = false;
		_position = false;
	}
	
	private void Update() {
		RaycastHit hitInfo;
		if ( Physics.Raycast( _transform.position, _transform.up, out hitInfo, _grabDistance ) &&
			hitInfo.collider.GetComponent< Grabbable >()) {
			_canInteract = hitInfo.collider.gameObject;
		} else {
			_canInteract = null;
		}
			
		if ( _grabButton.GetState() == 1) {
			_position = true;
			if ( !_grabbing && _canInteract ) {
				Transform other = hitInfo.collider.GetComponent< Transform >();
				hitInfo.collider.GetComponent< Grabbable >().Grab();
				other.SetParent( _transform );
				other.localPosition = _grabPosition.localPosition;
				_grabbedTransform = other;
				_grabbing = true;
			}
		} else if ( _grabButton.GetState() == 0 ) {
			_position = false;
			if(_grabbing && _grabbedTransform != null){
				_grabbedTransform.GetComponent< Grabbable >().Release();
				_grabbedTransform.parent = null;
				_grabbedTransform = null;
				_grabbing = false;
			}
		}

		if(_switch != _position){
			_switch = _position;
			if(_switch){//state is 1
				// HACK: Manually playing the animator clip
				_animator.SetBool("Grabbing", true);
				_grabbing = true;
			}else{//state is 0
				_animator.SetBool("Grabbing", false);
				_grabbing = false;
			}
			_animator.Play( _grabStateName );
		}


		if(_upperarmJoint.use != _released){
			_released = _upperarmJoint.use;
			if(!_released){
				currentRot = gameObject.transform.localRotation;
			}
		}
		if(_forearmJoint.use != _released){
			_released = _forearmJoint.use;
			if(!_released){
				currentRot = gameObject.transform.localRotation;
			}
		}
	}
}
