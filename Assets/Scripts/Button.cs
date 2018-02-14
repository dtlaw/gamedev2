using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, BinaryControl {

	// Exposed variables
	[ SerializeField ]
	private float _depressDepth;


	// Private variables
	private Transform _transform;

	private bool _state;


	// Messages
	private void Awake() {
		_transform = GetComponent< Transform >();
		_state = false;
	}

	private void OnMouseDown() {

		// TODO: Change to actual animation
		_transform.position -= _transform.up * _depressDepth;
		_state = true;
	}

	private void OnMouseUp() {

		// TODO: Change to actual animation
		_transform.position += _transform.up * _depressDepth;
		_state = false;
	}


	// Public interface
	public bool GetState() {
		return _state;
	}
}
