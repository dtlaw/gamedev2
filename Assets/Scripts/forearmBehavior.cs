using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forearmBehavior : MonoBehaviour {

	private HingeJoint _forearm;
	private JointMotor _muscle;
	private Rigidbody _forearmBody;

	[SerializeField]
	private int _muscleForce = 5;

	// Use this for initialization
	void Start () {
		_forearm = gameObject.GetComponent<HingeJoint>();
		_forearmBody = gameObject.GetComponent<Rigidbody>();
		_muscle = _forearm.motor;
		_forearm.motor = _muscle;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.O)){
			_forearm.useMotor = true;
			_muscle.force = _muscleForce;
			_muscle.targetVelocity = _muscleForce;
			_forearm.motor = _muscle;
			Debug.Log("O " + _muscle.targetVelocity);
		}else if(Input.GetKey(KeyCode.P)){
			_forearm.useMotor = true;
			_muscle.force = -(_muscleForce);
			_muscle.targetVelocity = -(_muscleForce);
			_forearm.motor = _muscle;
			Debug.Log("P " + _muscle.targetVelocity);
		}else{
			_forearm.useMotor = false;
			_muscle.force = 0;
			_forearmBody.velocity = Vector3.zero;
			_forearmBody.angularVelocity = Vector3.zero;
			Debug.Log("none " + _muscle.force);
		}
	}
}
