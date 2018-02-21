using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPositionSwitch : Control {

	// Exposed variables
	[ SerializeField ]
	private float _movementArc;
	[ SerializeField ]
	private Transform _pivot;


	// Messages
	private void Awake() {
		_state = 0;
		_pivot.Rotate( -_movementArc / 2, 0, 0 );
	}


	// Public interface
	public override void OnClick() {
		if ( _state > 0 ) {
			_state = 0;
			_pivot.Rotate( _movementArc, 0, 0 );
		} else {
			_state = 1;
			_pivot.Rotate( -_movementArc, 0, 0 );
		}
	}

	public override void OnRelease() {}
}
