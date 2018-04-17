using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour {

	// Private variables
	private Collider _collider;


	// Messages
	private void Awake() {
		_collider = GetComponent< Collider >();
	}
	
	private void Update() {
		if ( GameObject.Find( "TractorBeam" ).GetComponent< TractorBeam >()) {
		} else {
			_collider.enabled = true;
		}
	}

	public void Grabbed( bool b ) {
		_collider.enabled = b;
	}
}
