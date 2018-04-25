using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour {

	// Private variables
	private Collider _collider;

	private Hand _hand;
	private Movement _movement;


	// Messages
	private void Awake() {
		_collider = GetComponent< Collider >();
		
	}

	private void Start() {
		_hand = GameManager.Instance.GetComponent< CockpitReferences >().Hand;
		_movement = GameManager.Instance.GetComponent< CockpitReferences >().Movement;
	}
	
	private void Update() {
		if ( Vector3.Distance( transform.position, _hand.transform.position) < 0.8f ) {
			_movement.StepBack();
		}
	}

	public void Grabbed( bool b ) {
		_collider.enabled = b;
	}
}
