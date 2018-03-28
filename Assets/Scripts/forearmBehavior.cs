using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forearmBehavior : MonoBehaviour {

	private HingeJoint _forearm;
	private JointMotor _muscle;
	private Rigidbody _forearmBody;
	[ Header( "Arm buttons" ) ]
	[ SerializeField ]
	private Control _armLeft;
	[ SerializeField ]
	private Control _armRight;
	[ SerializeField ]
	private GameObject _wrist;
	//private Rigidbody _wristbody;

	[SerializeField]
	private int _muscleForce = 5;

	public bool use {get; set;}

	// Use this for initialization
	void Start () {
		_forearm = gameObject.GetComponent<HingeJoint>();
		_forearmBody = gameObject.GetComponent<Rigidbody>();
		_forearmBody.constraints = RigidbodyConstraints.FreezeRotationX;
		_forearmBody.constraints = RigidbodyConstraints.FreezeRotationY;
		_muscle = _forearm.motor;
		_forearm.motor = _muscle;
		use = false;
		//_wristbody = _wrist.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		/*
		if(_wrist.GetComponent<wristBehavior>().use == false){
			_wristbody.constraints = RigidbodyConstraints.FreezeRotation;
		}else{
			_wristbody.constraints = RigidbodyConstraints.None;
		}*/
		// if(Input.GetKey(KeyCode.O)){
		if (_armRight.IsOn()) {
			_forearmBody.constraints = RigidbodyConstraints.None;
			_forearm.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = _muscleForce;
			use = true;
		}
		// else if(Input.GetKey(KeyCode.P)){
		else if(_armLeft.IsOn()) {
			_forearmBody.constraints = RigidbodyConstraints.None;
			_forearm.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = -(_muscleForce);
			use = true;
		}else{
			_forearm.useMotor = false;
			_muscle.force = 0;
			use = false;
		}

		_forearm.motor = _muscle;
		_forearmBody.velocity = Vector3.zero;
		_forearmBody.angularVelocity = Vector3.zero;
	}
}
