using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handBehavior : MonoBehaviour {


	RaycastHit hitInfo;
	Vector3 fwdPos;
	private bool _grab {get; set;}
	private bool _interact;

	private HingeJoint _hand;
	private JointMotor _muscle;
	private Rigidbody _handBody;

	[SerializeField]
	private int _muscleForce = 500;

	[SerializeField]
	private float _dist = 5f;
	
	[ Header( "Arm buttons" ) ]
	[ SerializeField ]
	private Control _armGrab;
	[ SerializeField ]
	private Control _armDrop;

	private bool _pressed;
	// Use this for initialization
	void Start () {
		_hand = gameObject.GetComponent<HingeJoint>();
		_handBody = gameObject.GetComponent<Rigidbody>();
		_muscle = _hand.motor;
		_grab = false;
		_pressed = false;
		_interact = false;
	}
	
	public bool Grab() {
		return _grab;
	}

	public bool Interact() {
		return _interact;
	}

	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (this.transform.position, this.transform.up);
		Debug.DrawRay(this.transform.position, this.transform.up * _dist);
		if ((Physics.Raycast (ray, out hitInfo, _dist) && hitInfo.collider.tag == "interactable") || _grab) {
			_interact = true;
		} else {
			_interact = false;
		}
		if (_armGrab.IsOn() && !_pressed) {
			if(!_grab && Physics.Raycast (ray, out hitInfo, _dist) && hitInfo.collider.tag == "interactable"){
				Debug.Log ("Grabbed");
				_grab = true;
				hitInfo.collider.transform.SetParent(gameObject.transform);
			} else if (_grab){
				Debug.Log ("Dropped");
				_grab = false;
				transform.GetChild(2).parent = null;
				// hitInfo.collider.transform.parent = null;
			}
			_pressed = true;
		} else if (!_armGrab.IsOn()) {
			_pressed = false;
		}

		if (_armDrop.IsOn()) {
			_hand.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = _muscleForce;
		}else{
			_hand.useMotor = false;
			_muscle.force = 0;
		}
		_hand.motor = _muscle;
		_handBody.velocity = Vector3.zero;
		_handBody.angularVelocity = Vector3.zero;
	}
}
