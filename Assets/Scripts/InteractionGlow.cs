using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGlow : MonoBehaviour {

	private Light _light;

	// Use this for initialization
	void Start () {
		_light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Hand").GetComponent<handBehavior>().Interact() ||
			GameObject.Find("laser_beam").GetComponent<GrabBehavior>().Interact()) {
			_light.enabled = true;
		} else {
			_light.enabled = false;
		}


		if (GameObject.Find("Hand").GetComponent<handBehavior>().Grab() ||
			GameObject.Find("laser_beam").GetComponent<GrabBehavior>().Grab()) {
			_light.color = Color.green;
		} else {
			_light.color = Color.yellow;
		}
	}
}
