using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomLength : MonoBehaviour {

	[ SerializeField ]
	private GameObject _cockpit;

	private RectTransform _transform;
	private float _value;
	private float _prevWidth;
	private int count;
	private Vector3 _lastPosition;
	private Quaternion _lastRotation;
	private float _speed;
	private float _rotation;

	// Use this for initialization
	void Start () {
		count = 0;
		_prevWidth = 150;
		_transform = GetComponent< RectTransform >();
		_lastPosition = _cockpit.transform.position;
		_lastRotation = _cockpit.transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		_speed = (_cockpit.transform.position - _lastPosition).magnitude;
		_rotation = Quaternion.Angle(_cockpit.transform.rotation, _lastRotation);
		_lastPosition = _cockpit.transform.position;
		_lastRotation = _cockpit.transform.rotation;
		_value = Random.value * _prevWidth / 2;
		if (count % 4 != 0) {
		} else if ( _value > 0.5 * _prevWidth / 2) {
			_transform.sizeDelta = new Vector2( 2000 * (_speed + _rotation / 10) + _value, _transform.sizeDelta.y );
		} else {
			_transform.sizeDelta = new Vector2( 2000 * (_speed + _rotation / 10), _transform.sizeDelta.y );
		}
		count += 1;
		_prevWidth = _transform.sizeDelta.x;
	}
}