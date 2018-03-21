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

	public bool use {get; set;}

	// Use this for initialization
	void Start () {
		_shoulder = gameObject.GetComponent<HingeJoint>();
		_shoulderBody = gameObject.GetComponent<Rigidbody>();
		_muscle = _shoulder.motor;
		use = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (_armDown.IsOn()) {
			_shoulderBody.constraints = RigidbodyConstraints.None;
			_shoulder.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = _muscleForce;
			use = true;
		}else if (_armUp.IsOn()) {
			_shoulderBody.constraints = RigidbodyConstraints.None;
			_shoulder.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = -(_muscleForce);
			use = true;
		}else{
			_shoulder.useMotor = false;
			_muscle.force = 0;
			use = false;
		}
		_shoulder.motor = _muscle;
		_shoulderBody.velocity = Vector3.zero;
		_shoulderBody.angularVelocity = Vector3.zero;
	}
}
