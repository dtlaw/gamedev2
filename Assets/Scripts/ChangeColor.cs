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

		// TODO: Refactor this, this is bad
		if ( objectName == "Hand" ) {
			_grab = GameManager.Instance.GetComponent< CockpitReferences >().Hand.Grabbing;
		} else if ( objectName == "TractorBeam" ) {
			_grab = GameManager.Instance.GetComponent< CockpitReferences >().TractorBeam.Grabbing;
		}
		if ( _grab ) {
			_image.color = Color.green;
		} else {
			_image.color = Color.white;
		}
	}
}
