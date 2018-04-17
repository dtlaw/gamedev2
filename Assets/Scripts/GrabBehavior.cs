using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehavior : MonoBehaviour {

	RaycastHit hitInfo;
	Vector3 closestPos;
	private bool _grab {get; set;}
	bool on = false;
	ParticleSystem beam;
	private bool _interact;
	private Transform _grabbedTransform;

	
	[ Header( "Tractor buttons" ) ]
	[ SerializeField ]
	private Control _beamOn;

	private bool _pressed;

	// Use this for initialization
	private void Awake() {
		beam = transform.GetChild(1).GetComponent<ParticleSystem> ();
		_grab = false;
		_pressed = false;
		_interact = false;
		_grabbedTransform = null;
	}
	
	public bool Grab() {
		return _grab;
	}

	// Update is called once per frame
	private void Update() {
		Ray ray = new Ray (beam.transform.position, beam.transform.forward);

		// turn beam on/off
		if ( _beamOn.IsOn() && !_pressed ) {
			Debug.Log ("on/off");
			on = !on;
			_pressed = true;
		} else if ( !_beamOn.IsOn()) {
			_pressed = false;
		}

		if (!on) {
			_grab = false;
			beam.Stop ();
		} else {
			beam.Play ();
		}

		// grabbing and dropping
		if (Physics.Raycast (ray, out hitInfo) && beam.isPlaying) {
			if (hitInfo.collider.tag == "interactable" || _grab ) {
				_grab = true;
				hitInfo.collider.transform.SetParent(gameObject.transform.parent);
				_grabbedTransform = hitInfo.collider.transform;
				closestPos = transform.position + transform.forward * 1f;
				_grabbedTransform.position = Vector3.Lerp (_grabbedTransform.position, closestPos, 1 * Time.deltaTime);

			} 
		} else {
			if (_grabbedTransform != null) {
				_grabbedTransform.parent = null;
			}
		}
	}
}
