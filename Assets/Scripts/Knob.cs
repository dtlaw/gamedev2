using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : Control {

	// Exposed variables
	[ SerializeField ]
	private float _minValue;
	[ SerializeField ]
	private float _maxValue;
	[ SerializeField ]
	private float _increment;
	[ SerializeField ]
	private float _defaultValue;

	[ SerializeField ]
	private float _startRotation;
	[ SerializeField ]
	private float _endRotation;


	// Private variables
	private Transform _transform;


	// Messages
	private void Awake() {
		_transform = GetComponent< Transform >();

		_state = _defaultValue;
	}


	// Public interface
	public override void OnScrollUp() {
		_state = Mathf.Clamp( _state + _increment, _minValue, _maxValue );
		SetStateRotation();
	}

	public override void OnScrollDown() {
		_state = Mathf.Clamp( _state - _increment, _minValue, _maxValue );
		SetStateRotation();
	}

	public override void OnClick() {}
	public override void OnRelease() {}


	// Private interface
	private float NormalizedState() {
		return _state;
	}

	private void SetStateRotation() {

		// TODO: Convert normalized state into a rotation between min and max value
		float normalizedState = ( _state - _minValue ) / ( _maxValue - _minValue );
		float rotationRange = _endRotation - _startRotation;
		float rotation = rotationRange * normalizedState;

		_transform.localRotation = Quaternion.Euler( 0, _startRotation + rotation, 0 );
	}
}
