﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour {

	// Exposed variables
	[ SerializeField ]
	private ParticleSystem _beamParticles;

	[ SerializeField ]
	private Control _toggleButton;


	// Private variables
	private bool _pressed;
	private bool _beamOn;
	private bool _objectGrabbed;
	private Transform _grabbedTransform;


	// Messages
	private void Awake() {
		_pressed = false;
		_beamOn = true;
		_objectGrabbed = false;
	}

	private void Update() {
		if ( _toggleButton.IsOn() && !_pressed ) {
			if ( !_beamOn ) {
				_beamOn = true;
				_beamParticles.Play();
			} else {
				_beamOn = false;
				_beamParticles.Stop();
			}
			_pressed = true;
		} else if ( !_toggleButton.IsOn()) {
			_pressed = false;
		}

		RaycastHit hit;
		Transform beamTransform = _beamParticles.transform;
		if ( Physics.Raycast ( beamTransform.position, beamTransform.forward, out hit ) && _beamOn ) {
			Grabbable g = hit.collider.GetComponent< Grabbable >();
			if ( g || _objectGrabbed ) {
				_objectGrabbed = true;
				g.Grab();
				hit.collider.transform.SetParent( transform.parent );
				_grabbedTransform = hit.collider.transform;
				Vector3 closestPos = transform.position + transform.forward;
				_grabbedTransform.position = Vector3.Lerp ( _grabbedTransform.position, closestPos, Time.deltaTime );

			} 
		} else {
			if ( _grabbedTransform != null ) {
				Grabbable g = _grabbedTransform.GetComponent< Grabbable >();
				_grabbedTransform.parent = null;
				_objectGrabbed = false;
				g.Release();
			}
		}
	}
}
