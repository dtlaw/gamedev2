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


	// Public interface
	public override void OnClick() {
		if ( _state > 0 ) {
			_state = 0;
			_animator.SetFloat( "NormalizedTime", 0 );
		} else {
			_state = 1;
			_animator.SetFloat( "NormalizedTime", 1 );
		}
	}

	public override void OnRelease() {}

	public override void OnScrollUp() {}
	public override void OnScrollDown() {}
}
