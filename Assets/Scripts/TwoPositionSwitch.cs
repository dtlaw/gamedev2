using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPositionSwitch : Control {

	// Exposed variables
	[ SerializeField ]
	private Animator _animator;


	// Messages
	private void Awake() {
		_state = 0;
		_animator.SetFloat( "NormalizedTime", 0 );
	}

	private void Update() {
		_animator.SetFloat( "NormalizedTime", _state );
	}


	// Public interface
	public override void OnClick() {
		if ( _state > 0 ) {
			_state = 0;
		} else {
			_state = 1;
		}
	}
}
