using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomLength : MonoBehaviour {

	private RectTransform _transform;
	private float _value;
	private float _prevWidth;
	private int count;

	// Use this for initialization
	void Start () {
		count = 0;
		_prevWidth = 150;
		_transform = GetComponent< RectTransform >();
	}
	
	// Update is called once per frame
	void Update () {

		_value = Random.value * _prevWidth / 2;
		if (count % 4 != 0) {
		} else if ( _value > 0.5 * _prevWidth / 2) {
			_transform.sizeDelta = new Vector2( 150 + _value, _transform.sizeDelta.y );
		} else {
			_transform.sizeDelta = new Vector2( 150 - _value, _transform.sizeDelta.y );
		}
		count += 1;
		_prevWidth = _transform.sizeDelta.x;
	}
}
