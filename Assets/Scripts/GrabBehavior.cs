﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehavior : MonoBehaviour {

	RaycastHit hitInfo;
	Vector3 fwdPos;
	private bool _grab {get; set;}
	bool on = false;
	ParticleSystem beam;
	
	[ Header( "Tractor buttons" ) ]
	[ SerializeField ]
	private Control _beamOn;
	[ SerializeField ]
	private Control _beamIn;
	[ SerializeField ]
	private Control _beamOut;
	[ SerializeField ]
	private Control _beamGrab;
	[ SerializeField ]
	private Control _beamDrop;

	bool _pressed;

	// Use this for initialization
	private void Awake() {
		beam = transform.GetChild(1).GetComponent<ParticleSystem> ();
		_grab = false;
		_pressed = false;
	}
	
	// Update is called once per frame
	private void Update() {
		Ray ray = new Ray (this.transform.position, this.transform.forward);
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 5.0f;

		// turn beam on/off
		// if (Input.GetKeyDown ("t")) {
		if ( _beamOn.IsOn() && !_pressed ) {
			Debug.Log ("on/off");
			on = !on;
			_pressed = true;
			/*if (beam.isPlaying) {
				beam.Stop ();
			} else {
				beam.Play ();
			}*/
		} else if ( !_beamOn.IsOn()) {
			_pressed = false;
		}
		if (!on) {
			beam.Stop ();
		} else {
			beam.Play ();
		}
			
		if(_grab){
			if (hitInfo.collider.tag == "interactable") {
				if(_beamIn.IsOn()){
					hitInfo.collider.transform.position = Vector3.Lerp (hitInfo.collider.transform.position, transform.position, 1 * Time.deltaTime);
				}else if(_beamOut.IsOn()){
					fwdPos = transform.position + transform.forward * 10f;
					hitInfo.collider.transform.position = Vector3.Lerp (hitInfo.collider.transform.position, fwdPos, 1 * Time.deltaTime);
				}
			}
		}

		// e for grabbing, r for pushing away
		if (Physics.Raycast (ray, out hitInfo, 100f) && beam.isPlaying) {
			if (hitInfo.collider.tag == "interactable") {
				if (_beamGrab.IsOn()) {
					Debug.Log ("Grabbed");
					_grab = true;
					hitInfo.collider.transform.SetParent(gameObject.transform);
				} else if (_beamDrop.IsOn()) {
					Debug.Log ("Dropped");
					_grab = false;
					on = !on;
					hitInfo.collider.transform.parent = null;
				}

			}
		}

		// transform.Rotate (0, x, 0);
		// transform.Translate (0, 0, z);


	}
}
