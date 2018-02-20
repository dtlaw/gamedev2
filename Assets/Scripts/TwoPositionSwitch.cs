using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPositionSwitch : MonoBehaviour, BinaryControl {

	// Exposed variables
	[ SerializeField ]
	private float _movementArc;
	[ SerializeField ]
	private Transform _pivot;


	// Private variables
	private bool _state;


	// Messages
	private void Awake() {
		_state = false;
		_pivot.Rotate( -_movementArc / 2, 0, 0 );
	}

	private void OnMouseDown() {
		_state = !_state;

		if ( _state == true ) {
			_pivot.Rotate( _movementArc, 0, 0 );
		} else {
			_pivot.Rotate( -_movementArc, 0, 0 );
		}
	}


	// Public interface
	public bool GetState() {
		return _state;
	}
}
