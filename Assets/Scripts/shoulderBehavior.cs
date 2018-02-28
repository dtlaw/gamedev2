using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoulderBehavior : MonoBehaviour {

	private HingeJoint _shoulder;
	private JointMotor _muscle;
	private Rigidbody _shoulderBody;
	
	[SerializeField]
	private int _muscleForce = 500;
	
	[ Header( "Arm buttons" ) ]
	[ SerializeField ]
	private Control _armUp;
	[ SerializeField ]
	private Control _armDown;

	// Use this for initialization
	void Start () {
		_shoulder = gameObject.GetComponent<HingeJoint>();
		_shoulderBody = gameObject.GetComponent<Rigidbody>();
		_muscle = _shoulder.motor;
	}
	
	// Update is called once per frame
	void Update () {
		// if(Input.GetKey(KeyCode.Q)){
		if (_armUp.IsOn()) {
			_shoulderBody.constraints = RigidbodyConstraints.None;
			_shoulder.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = _muscleForce;
		}
		//else if(Input.GetKey(KeyCode.W)){
		else if (_armDown.IsOn()) {
			_shoulderBody.constraints = RigidbodyConstraints.None;
			_shoulder.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = -(_muscleForce);
		}else{
			_shoulderBody.constraints = RigidbodyConstraints.FreezeAll;
			_shoulder.useMotor = false;
			_muscle.force = 0;
		}
		_shoulder.motor = _muscle;
		_shoulderBody.velocity = Vector3.zero;
		_shoulderBody.angularVelocity = Vector3.zero;
	}
}
