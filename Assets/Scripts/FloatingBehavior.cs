using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBehavior : MonoBehaviour {

    private float _amplitude = 0.15f;
    private float _frequency = 1f;
    private bool _grab = false;
 
    // Position Storage Variables
    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();

	// Use this for initialization
	void Start () {
		posOffset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Hand").GetComponent<handBehavior>().Grab() ||
			GameObject.Find("laser_beam").GetComponent<GrabBehavior>().Grab()) {
			_grab = true;
		}
		if (!_grab) {
			tempPos = posOffset;
	        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * _frequency) * _amplitude;
	 
	        transform.position = tempPos;
		}
	}
}
