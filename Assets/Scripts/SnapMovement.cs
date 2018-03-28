using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMovement : MonoBehaviour {
	private bool _snap;
	private Vector3 _doorPos;
	[ SerializeField ]
	private GameObject goal;

	[ SerializeField ]
	private GameObject door;
	// Use this for initialization
	void Start () {
		_snap = false;
		_doorPos = door.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance( transform.position, goal.transform.position ) <= 0.8 && !_snap) {
			if (GameObject.Find("Hand").GetComponent<handBehavior>().Grab()) {
				GameObject.Find("Hand").GetComponent<handBehavior>().setGrabFalse();
			}
			if (GameObject.Find("laser_beam").GetComponent<GrabBehavior>().Grab()) {
				GameObject.Find("laser_beam").GetComponent<GrabBehavior>().setGrabFalse();
			}
			_snap = true ;
		}

		if (_snap) {
			transform.rotation= Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
			transform.position = Vector3.Lerp(transform.position, goal.transform.position, Time.time);
			door.transform.position = Vector3.Lerp(door.transform.position, _doorPos + new Vector3(7.5f, 0.0f, 0.0f), 0.01f) ;
		}
	}
}
