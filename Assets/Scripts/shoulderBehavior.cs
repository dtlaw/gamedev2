﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoulderBehavior : MonoBehaviour {

	private HingeJoint _shoulder;
	private JointMotor _muscle;
	private Rigidbody _shoulderBody;

	[SerializeField]
	private int _muscleForce = 500;

	// Use this for initialization
	void Start () {
		_shoulder = gameObject.GetComponent<HingeJoint>();
		_shoulderBody = gameObject.GetComponent<Rigidbody>();
		_muscle = _shoulder.motor;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Q)){
			_shoulder.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = _muscleForce;
			_shoulder.motor = _muscle;
			Debug.Log("Q " + _shoulder.motor.targetVelocity);
		}else if(Input.GetKey(KeyCode.W)){
			_shoulder.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = -(_muscleForce);
			_shoulder.motor = _muscle;
			Debug.Log("W " + _shoulder.motor.targetVelocity);
		}else{
			_shoulder.useMotor = false;
			_muscle.force = 0;
			_shoulderBody.velocity = Vector3.zero;
			_shoulderBody.angularVelocity = Vector3.zero;
			Debug.Log("none " + _shoulder.motor.targetVelocity);
		}
	}
}