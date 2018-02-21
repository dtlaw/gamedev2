using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Control {

	// Exposed variables
	[ SerializeField ]
	private float _depressDepth;


	// Private variables
	private Transform _transform;


	// Messages
	private void Awake() {
		_transform = GetComponent< Transform >();
		_state = 0;
	}


	// Public interface
	public override void OnClick() {

		// TODO: Change to actual animation
		_transform.position -= _transform.up * _depressDepth;
		_state = 1;
	}

	public override void OnRelease() {

		// TODO: Change to actual animation
		_transform.position += _transform.up * _depressDepth;
		_state = 0;
	}
}
