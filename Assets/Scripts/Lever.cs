using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Control {

	// Exposed variables
	[ SerializeField ]
	private float _minValue;
	[ SerializeField ]
	private float _maxValue;
	[ SerializeField ]
	private float _defaultValue;
	[ SerializeField ]
	private Transform _startPoint;
	[ SerializeField ]
	private Transform _endPoint;
	[ SerializeField ]
	private float _movementArc;
	[ SerializeField ]
	private Transform _pivot;


	// Private variables
	private Transform _transform;
	private Camera _camera;

	private bool _gripped;


	// Messages
	private void Awake() {
		_transform = GetComponent< Transform >();
		_camera = Camera.main;

		_state = _defaultValue;
		_gripped = false;

		_pivot.Rotate( -_movementArc / 2, 0, 0 );
	}
	
	private void Update() {
		if ( _gripped ) {

			// Get relative position of mouse and set lever state to that
			Vector3 start = _camera.WorldToScreenPoint( _startPoint.position );
			start.z = 0;
			Vector3 end = _camera.WorldToScreenPoint( _endPoint.position );
			end.z = 0;
			Vector3 track = new Vector3( end.x - start.x, end.y - start.y, end.z - start.z );
			Vector3 mousePos = Input.mousePosition;

			if (( mousePos.x > start.x && mousePos.x < end.x ) || ( mousePos.y > start.y && mousePos.y < end.y )) {
				Vector3 projection = Vector3.Project( mousePos - start, track );
				projection = Vector3.ClampMagnitude( projection, track.magnitude );

				_state = projection.magnitude / track.magnitude;
				_pivot.localRotation = Quaternion.Euler( _movementArc * ( _state - 0.5f ), 0, 0 );
			}
		}
	}


	// Public interface
	public override void OnClick() {
		_gripped = true;
	}

	public override void OnRelease() {
		_gripped = false;
	}
}
