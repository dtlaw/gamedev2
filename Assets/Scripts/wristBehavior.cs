using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wristBehavior : MonoBehaviour {

	private HingeJoint _wrist;
	private JointMotor _muscle;
	private Rigidbody _wristBody;

	[SerializeField]
	private int _muscleForce = 5;

	public bool use {get; set;}

	// Use this for initialization
	void Start () {
		_wrist = gameObject.GetComponent<HingeJoint>();
		_wristBody = gameObject.GetComponent<Rigidbody>();
		_muscle = _wrist.motor;
		_wrist.motor = _muscle;
		use = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.O)){
			_wristBody.constraints = RigidbodyConstraints.None;
			_wrist.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = _muscleForce;
			use = true;
		}
		 else if(Input.GetKey(KeyCode.P)){
			_wristBody.constraints = RigidbodyConstraints.None;
			_wrist.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = -(_muscleForce);
			use = true;
		}else{
			_wrist.useMotor = false;
			_muscle.force = 0;
			use = false;
		}

		_wrist.motor = _muscle;
		_wristBody.velocity = Vector3.zero;
		_wristBody.angularVelocity = Vector3.zero;
	}
}
