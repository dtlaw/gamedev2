using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehavior : MonoBehaviour {

	RaycastHit hitInfo;
	Vector3 fwdPos;
	private bool _grab {get; set;}
	bool on = false;
	ParticleSystem beam;
	private bool _interact;
	private Transform _grabbedTransform;

	
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

	public bool Interact() {
		return _interact;
	}

	public void setGrabFalse() {
		_grab = false;
		_grabbedTransform.parent = null;
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
			
		if(_grab){
			if(_beamIn.IsOn()){
				Debug.Log("In");
				_grabbedTransform.position = Vector3.Lerp (_grabbedTransform.position, transform.position, 1 * Time.deltaTime);
			}else if(_beamOut.IsOn()){
				Debug.Log("Out");
				fwdPos = transform.position + transform.forward * 10f;
				_grabbedTransform.position = Vector3.Lerp (_grabbedTransform.position, fwdPos, 1 * Time.deltaTime);
			}
		} 

		// grabbing and dropping
		if (Physics.Raycast (ray, out hitInfo) && beam.isPlaying) {
			if (hitInfo.collider.tag == "interactable" || _grab ) {
				_interact = true;
				// grab
				if (_beamGrab.IsOn()) {
					Debug.Log ("Grabbed");
					_grab = true;
					hitInfo.collider.transform.SetParent(gameObject.transform);
					_grabbedTransform = hitInfo.collider.transform;
				} 
				// drop
				else if (_beamDrop.IsOn()) {
					Debug.Log ("Dropped");
					_grab = false;
					_grabbedTransform.parent = null;
					// hitInfo.collider.transform.parent = null;
					on = !on;
				} 
			} else {
				_interact = false;
			}
		} else {
			_interact = false;
		}
	}
}
