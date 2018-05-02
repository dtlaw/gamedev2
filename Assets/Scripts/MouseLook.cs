using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	// Exposed variables
	[ SerializeField ]
	private float _maxRotation;
	[ SerializeField ]
	private float _lerpFraction;


	// Private variables
	private Transform _transform;
	private Quaternion _neutralPosition;


	// Messages
	private void Awake() {
		_transform = GetComponent< Transform >();
		_neutralPosition = _transform.localRotation;
	}
	
	private void Update() {
		if ( Input.GetMouseButton( 1 )) {
			Vector2 mousePosition = Input.mousePosition;

			Vector2 normalizedPosition;
			normalizedPosition.x = ( mousePosition.x - Screen.width / 2 ) / Screen.width;
			normalizedPosition.y = ( mousePosition.y - Screen.height / 2 ) / Screen.height;

			Quaternion targetRotation = Quaternion.Euler( -normalizedPosition.y * _maxRotation, normalizedPosition.x * _maxRotation, 0 );
			_transform.localRotation = Quaternion.Lerp( _transform.localRotation, targetRotation, _lerpFraction );
		} else {

			// Move back towards neutral position
			_transform.localRotation = Quaternion.Lerp( _transform.localRotation, _neutralPosition, _lerpFraction );
		}
	}
}
