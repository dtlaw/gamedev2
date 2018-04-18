using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jointMotor : MonoBehaviour {
	
	private HingeJoint _joint;
	private JointMotor _muscle;
	private Rigidbody _rigidBody;

	[SerializeField]
	private int _muscleForce = 500;

	[ Header( "Arm buttons" ) ]
	[ SerializeField ]
	private Control _armPos;
	[ SerializeField ]
	private Control _armNeg;

	[ SerializeField ]
	private GameObject _parent;
	private jointMotor _parentJoint;

	public Quaternion currentRot {get; set;}
	public bool use {get; set;}
	private bool _released;

	void Start () {
		_joint = gameObject.GetComponent<HingeJoint>();
		_rigidBody = gameObject.GetComponent<Rigidbody>();
		_muscle = _joint.motor;
		currentRot = gameObject.transform.localRotation;
		use = false;
		_released = false;
		if(_parent != null) _parentJoint = _parent.GetComponent<jointMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_armPos.IsOn()) {
			_joint.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = _muscleForce;
			use = true;
		}else if (_armNeg.IsOn()) {
			_joint.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = -(_muscleForce);
			use = true;
		}else{
			_joint.useMotor = false;
			_muscle.force = 0;
			use = false;
		}

		if(_parent != null){
			if(_parentJoint.use != _released){
				_released = _parentJoint.use;
				if(!_released){
					currentRot = gameObject.transform.localRotation;
				}
			}
		}

		if(use != _released){
			_released = use;
			if(!_released){
				currentRot = gameObject.transform.localRotation;
			}
		}

		_joint.motor = _muscle;
		_rigidBody.velocity = Vector3.zero;
		_rigidBody.angularVelocity = Vector3.zero;
	}
}
