using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Control : MonoBehaviour {

	// Private variables
	protected float _state;


	// Public interface
	public abstract void OnClick();
	public abstract void OnRelease();

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
}
