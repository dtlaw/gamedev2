using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBehavior : MonoBehaviour {

	// Exposed variables
	[ SerializeField ]
    private float _amplitude = 0.08f;
	[ SerializeField ]
    private float _frequency = 1f;


    // Private variables
	private Grabbable _grabbable;

    private Vector3 posOffset;
	private bool _beenGrabbed;


	// Messages
	private void Awake() {
		_grabbable = GetComponent< Grabbable >();

		posOffset = transform.position;
		_beenGrabbed = false;
	}

	private void Update() {
		if ( _grabbable.Grabbed ) {
			_beenGrabbed = true;
		}

		if ( !_beenGrabbed ) {
			Vector3 tempPos = posOffset;
	        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * _frequency) * _amplitude;
	 
	        transform.position = tempPos;
		}
	}
}
