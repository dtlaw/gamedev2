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

	[ SerializeField ]
	private float _mouseMultiplier;
	[ SerializeField ]
	private float _centerThreshold;


	// Private variables
	private Transform _transform;

	private bool _gripped;


	// Messages
	private void Awake() {
		_transform = GetComponent< Transform >();

		_state = _defaultValue;
		_gripped = false;

		float normalizedState = ( _state - _minValue ) / ( _maxValue - _minValue );
		float rotationRange = _endRotation - _startRotation;
		float rotation = rotationRange * normalizedState;

		_transform.localRotation = Quaternion.Euler( 0, _startRotation + rotation, 0 );
	}

	private void Update() {

		if ( _gripped ) {
			_state = Mathf.Clamp( _state + Input.GetAxis( "Mouse Y" ) * _mouseMultiplier, _minValue, _maxValue );
		}

		// Convert normalized state into a rotation between min and max value
		float normalizedState = ( _state - _minValue ) / ( _maxValue - _minValue );
		float rotationRange = _endRotation - _startRotation;
		float rotation = rotationRange * normalizedState;

		_transform.localRotation = Quaternion.Euler( 0, _startRotation + rotation, 0 );
	}


	// Public interface
	public override void OnClick() {
		_gripped = true;
	}

	public override void OnRelease() {
		_gripped = false;

		if ( Mathf.Abs( _defaultValue - _state ) < _centerThreshold ) {
			_state = _defaultValue;
		}
	}

	public override void OnScrollUp() {
		_state = Mathf.Clamp( _state + _increment, _minValue, _maxValue );
	}

	public override void OnScrollDown() {
		_state = Mathf.Clamp( _state - _increment, _minValue, _maxValue );
	}
}
