using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMovement : MonoBehaviour {
	private bool snap;
	[ SerializeField ]
	private GameObject goal;

	[ SerializeField ]
	private GameObject door;
	// Use this for initialization
	void Start () {
		snap = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance( transform.position, goal.transform.position ) <= 0.4 && !snap) {
			GameObject.Find("Hand").GetComponent<handBehavior>().setGrabFalse();
			snap = true ;
		}

		if (snap) {
			transform.rotation= Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
			transform.position = Vector3.Lerp(transform.position, goal.transform.position, Time.time);
			door.transform.position = Vector3.Lerp(door.transform.position, door.transform.position + new Vector3(5.0f, 0.0f, 0.0f), 0.01f) ;
		}
	}
}
