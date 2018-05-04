using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour {
	// public variables
	public ParticleSystem deathParticles;
	// Private variables
	private Collider _collider;

	private Hand _hand;
	private Movement _movement;
	private ParticleSystem _self;


	// Messages
	private void Awake() {
		_collider = GetComponent< Collider >();
		_self = GetComponent< ParticleSystem >();
		
	}

	private void Start() {
		_collider.enabled = false;
		_hand = GameManager.Instance.GetComponent< CockpitReferences >().Hand;
		_movement = GameManager.Instance.GetComponent< CockpitReferences >().Movement;
	}
	
	private void Update() {
		if ( Vector3.Distance( transform.position, _hand.transform.position) < 0.8f ) {
			_movement.StepBack();
			// particle systems for collision
			deathParticles.startColor = _self.startColor;
			Instantiate(deathParticles, _hand.transform.position, Quaternion.identity);
		}
	}

	public void Grabbed( bool b ) {
		_collider.enabled = b;
	}
}
