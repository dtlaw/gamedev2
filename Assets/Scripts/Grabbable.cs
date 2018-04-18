using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour {

	// Public variables
	private bool _grabbed;
	public bool Grabbed { get { return _grabbed; }}

	// Private variables
	private Collider _collider;
	private Light _highlight;


	// Messages
	private void Awake() {
		_collider = GetComponent< Collider >();
		_highlight = GetComponent< Light >();
		_grabbed = false;
	}


	// Public interface
	public void Grab() {
		_collider.enabled = false;
		_grabbed = true;
	}

	public void Release() {
		_collider.enabled = true;
		_grabbed = false;
	}
}
