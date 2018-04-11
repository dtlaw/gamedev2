using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Control {

	// Constants
	private const float ROLLOVER_THRESHOLD = 0.01f;


	// Exposed variables
	[ SerializeField ]
	private Animator _animator;
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
	private float _detentThreshold;


	// Private variables
	private Transform _transform;
	private Camera _camera;

	private bool _gripped;


	// Messages
	private void Awake() {
		_transform = GetComponent< Transform >();
		_camera = Camera.main;

		_state = _defaultValue;
		_animator.SetFloat( "NormalizedTime", ( _defaultValue - _minValue ) / ( _maxValue - _minValue ));
		_gripped = false;
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

			Vector3 projection = Vector3.Project( mousePos - start, track );
			projection = Vector3.ClampMagnitude( projection, track.magnitude );

			if ( projection.x > ROLLOVER_THRESHOLD| projection.y < -ROLLOVER_THRESHOLD ) {
				_state = (( projection.magnitude / track.magnitude ) * ( _maxValue - _minValue )) + _minValue;
			}
		}

		_animator.SetFloat( "NormalizedTime", ( _state - _minValue ) / ( _maxValue - _minValue ));
	}


	// Public interface
	public override void OnClick() {
		_gripped = true;
	}

	public override void OnRelease() {
		_gripped = false;

		if ( Mathf.Abs( _defaultValue - _state ) < _detentThreshold ) {
			_state = _defaultValue;
		}
	}
}
