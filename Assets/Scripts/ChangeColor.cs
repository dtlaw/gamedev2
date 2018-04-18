using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour {
	public string objectName;
	private Image _image;
	private bool _grab;


	// Messages
	private void Start() {
		_image = GetComponent< Image >();
	}
	
	private void Update () {
		if ( objectName == "Hand" ) {
			_grab = GameObject.Find( objectName ).GetComponent< Hand >().Grabbing;
		} else if ( objectName == "TractorBeam" ) {
			_grab = GameObject.Find( objectName ).GetComponent< GrabBehavior >().Grab();
		}
		if ( _grab ) {
			_image.color = Color.green;
		} else {
			_image.color = Color.white;
		}
	}
}
