using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGlow : MonoBehaviour {

	// Private variables
	private Light _light;


	// Messages
	private void Awake() {
		_light = GetComponent<Light>();
	}
	
	private void Update() {

		// TODO: Refactor into Grabbable.cs
		Hand h = GameManager.Instance.GetComponent< CockpitReferences >().Hand;
		if ( h.CanInteract == gameObject ) {
			_light.enabled = true;
		} else {
			_light.enabled = false;
		}
	}
}
