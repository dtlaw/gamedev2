using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Control {

	// Exposed variables
	[ SerializeField ]
	private Animator _animator;


	// Messages
	private void Awake() {
		_state = 0;
	}


	// Public interface
	public override void OnClick() {

		// TODO: Change to actual animation
		_animator.SetFloat( "NormalizedTime", 1 );
		_state = 1;
	}

	public override void OnRelease() {

		// TODO: Change to actual animation
		_animator.SetFloat( "NormalizedTime", 0 );
		_state = 0;
	}
}
