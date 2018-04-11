using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour {
	public string objectName;
	private Image _image;
	private bool _grab;
	// Use this for initialization
	void Start () {
		_image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (objectName == "Hand") {
			_grab = GameObject.Find(objectName).GetComponent<handBehavior>().Grab();
		} else if (objectName == "laser_beam") {
			_grab = GameObject.Find(objectName).GetComponent<GrabBehavior>().Grab();
		}
		if ( _grab ) {
			_image.color = Color.green;
		} else {
			_image.color = Color.white;
		}
	}
}
