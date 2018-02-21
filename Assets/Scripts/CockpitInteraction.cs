using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitInteraction : MonoBehaviour {

	// Exposed variables
	[ SerializeField ]
	private LayerMask _clickableMask;


	// Private variables
	private Camera _camera;
	private Control _control;


	// Messages
	private void Awake() {
		_camera = Camera.main;
		_control = null;
	}
	
	private void Update() {
		if ( Input.GetMouseButtonDown( 0 )) {
			Ray r = _camera.ScreenPointToRay( Input.mousePosition );

			RaycastHit hit;
			if ( Physics.Raycast( r, out hit, Mathf.Infinity, _clickableMask )) {
				GameObject g = hit.collider.gameObject;

				_control = g.GetComponent< Control >();

				if ( _control ) {
					_control.OnClick();
				}
			}
		} else if ( Input.GetMouseButtonUp( 0 )) {
			if ( _control ) {
				_control.OnRelease();
				_control = null;
			}
		}
	}
}
