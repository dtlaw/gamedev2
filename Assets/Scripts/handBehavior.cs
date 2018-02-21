using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handBehavior : MonoBehaviour {


	RaycastHit hitInfo;
	Vector3 fwdPos;
	private bool _grab {get; set;}

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

	// Use this for initialization
	void Start () {
		_hand = gameObject.GetComponent<HingeJoint>();
		_handBody = gameObject.GetComponent<Rigidbody>();
		_muscle = _hand.motor;
		_grab = false;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (this.transform.position, this.transform.up);
		Debug.DrawRay(this.transform.position, this.transform.up * _dist);

		// if (Input.GetKeyDown (KeyCode.E)) {
		if (_armGrab.IsOn()) {
			if(!_grab && Physics.Raycast (ray, out hitInfo, _dist) && hitInfo.collider.tag == "interactable"){
				Debug.Log ("Grabbed");
				_grab = true;
				hitInfo.collider.transform.SetParent(gameObject.transform);
			}else{
				Debug.Log ("Dropped");
				_grab = false;
				hitInfo.collider.transform.parent = null;
			}
		}

		// if(Input.GetKey(KeyCode.R)){
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
