using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Control : MonoBehaviour {

	// Private variables
	protected float _state;


	// Public interface
	public virtual void OnClick() {}
	public virtual void OnRelease() {}
	public virtual void OnScrollUp() {}
	public virtual void OnScrollDown() {}

	public float GetState() {
		return _state;
	}

	public bool IsOn() {
		if ( _state > 0 ) {
			return true;
		} else {
			return false;
		}
	}

	public void Zero() {
		_state = 0;
	}
}
