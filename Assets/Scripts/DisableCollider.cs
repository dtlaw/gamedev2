using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour {
	private BoxCollider _collider;
	// Use this for initialization
	void Start () {
		_collider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Hand").GetComponent<handBehavior>().Grab() ||
			GameObject.Find("laser_beam").GetComponent<GrabBehavior>().Grab()) {
			_collider.enabled = false;
		} else {
			_collider.enabled = true;
		}
		// _collider.enabled = false;
	}
}
