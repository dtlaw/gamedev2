using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {
	// Exposed variables
	[ Header( "Movement forces" ) ]
	[ SerializeField ]
	private float _translationForce;
	[ SerializeField ]
	private float _pitchTorque;
	[ SerializeField ]
	private float _rollTorque;
	[ SerializeField ]
	private float _yawTorque;
	[ SerializeField ]
	private float _panicSpeed;

	[ Header( "Movement buttons" ) ]
	[ SerializeField ]
	private Control _forwardAxis;
	[ SerializeField ]
	private Control _strafeAxis;
	[ SerializeField ]
	private Control _moveUp;
	[ SerializeField ]
	private Control _moveDown;

	[ Space ]
	[ SerializeField ]
	private Control _pitchUp;
	[ SerializeField ]
	private Control _pitchDown;
	[ SerializeField ]
	private Control _rollAxis;
	[ SerializeField ]
	private Control _yawAxis;

	[ Space ]
	[ SerializeField ]
	private Control _panic;

	[ Space ]
	[ SerializeField ]
	private GameObject _shoulder;
	[ SerializeField ]
	private GameObject _forearm;
	[ SerializeField ]
	private GameObject _hand;

	[ Header( "Thruster Particles" ) ]
	[ SerializeField ]
	private ParticleSystem _thruster1;
	[ SerializeField ]
	private ParticleSystem _thruster2;
	[ SerializeField ]
	private ParticleSystem _thruster3;
	[ SerializeField ]
	private ParticleSystem _thruster4;
	[ SerializeField ]
	private ParticleSystem _thruster5;
	[ SerializeField ]
	private ParticleSystem _thruster6;
	[ SerializeField ]
	private ParticleSystem _thruster7;
	[ SerializeField ]
	private ParticleSystem _thruster8;
	
	[ Header( "Movement UI" ) ]
	[ SerializeField ]
	private GameObject _forwardUI;
	[ SerializeField ]
	private GameObject _backwardUI;
	[ SerializeField ]
	private GameObject _leftUI;
	[ SerializeField ]
	private GameObject _rightUI;
	[ SerializeField ]
	private GameObject _pitchUpUI;
	[ SerializeField ]
	private GameObject _pitchDownUI;
	[ SerializeField ]
	private GameObject _rollUpUI;
	[ SerializeField ]
	private GameObject _rollDownUI;
	[ SerializeField ]
	private GameObject _yawLeftUI;
	[ SerializeField ]
	private GameObject _yawRightUI;
	[ SerializeField ]
	private GameObject _upUI;
	[ SerializeField ]
	private GameObject _downUI;

	// Private variables
	private Rigidbody _rigidbody;
	private Rigidbody _shoulderbody;
	private Rigidbody _forearmbody;
	private Rigidbody _handbody;

	// Messages
	private void Awake() {
		_rigidbody = GetComponent<Rigidbody>();
		_shoulderbody = _shoulder.GetComponent<Rigidbody>();
		_forearmbody = _forearm.GetComponent<Rigidbody>();
		_handbody = _hand.GetComponent<Rigidbody>();
	}

	private void Update() {

		_thruster1.Stop();
		_thruster2.Stop();
		_thruster3.Stop();
		_thruster4.Stop();
		_thruster5.Stop();
		_thruster6.Stop();
		_thruster7.Stop();
		_thruster8.Stop();

		_forwardUI.SetActive(false);
		_backwardUI.SetActive(false);
		_leftUI.SetActive(false);
		_rightUI.SetActive(false);
		_pitchUpUI.SetActive(false);
		_pitchDownUI.SetActive(false);
		_rollUpUI.SetActive(false);
		_rollDownUI.SetActive(false);
		_yawLeftUI.SetActive(false);
		_yawRightUI.SetActive(false);
		_upUI.SetActive(false);
		_downUI.SetActive(false);

		if ( _shoulder.GetComponent<jointMotor>().use == false &&
			_forearm.GetComponent<jointMotor>().use == false ) {
			_shoulderbody.constraints = RigidbodyConstraints.FreezePosition;
			_forearmbody.constraints = RigidbodyConstraints.FreezePosition;
			_handbody.constraints = RigidbodyConstraints.FreezePosition;

			_shoulder.transform.localRotation = _shoulder.GetComponent<jointMotor>().currentRot;
			_forearm.transform.localRotation = _forearm.GetComponent<jointMotor>().currentRot;
			_hand.transform.localRotation = _hand.GetComponent<Hand>().currentRot;
		} else {
			_shoulderbody.constraints = RigidbodyConstraints.None;
			_forearmbody.constraints = RigidbodyConstraints.None;
			_handbody.constraints = RigidbodyConstraints.None;
		}
		
		_rigidbody.AddRelativeForce( Vector3.forward * _translationForce * -_forwardAxis.GetState());
		if ( _forwardAxis.GetState() < 0 ) {
			_forwardUI.SetActive(true);
			_thruster5.Play();
			_thruster6.Play();
			_thruster7.Play();
			_thruster8.Play();
		} else if ( _forwardAxis.GetState() > 0 ) {
			_backwardUI.SetActive(true);
			_thruster1.Play();
			_thruster2.Play();
			_thruster3.Play();
			_thruster4.Play();
		}

		_rigidbody.AddRelativeForce( Vector3.right * _translationForce * _strafeAxis.GetState());
		if ( _strafeAxis.GetState() < 0 ) {
			_leftUI.SetActive(true);
			_thruster1.Play();
			_thruster2.Play();
			_thruster5.Play();
			_thruster6.Play();
		} else if ( _strafeAxis.GetState() > 0 ) {
			_rightUI.SetActive(true);
			_thruster3.Play();
			_thruster4.Play();
			_thruster7.Play();
			_thruster8.Play();
		}

		if ( _moveUp.IsOn()) {
			_upUI.SetActive(true);
			_rigidbody.AddRelativeForce(Vector3.up * _translationForce);
			_thruster2.Play();
			_thruster4.Play();
			_thruster6.Play();
			_thruster8.Play();
		} else if ( _moveDown.IsOn()) {
			_downUI.SetActive(true);
			_rigidbody.AddRelativeForce(Vector3.down * _translationForce);
			_thruster1.Play();
			_thruster3.Play();
			_thruster5.Play();
			_thruster7.Play();
		}

		if ( _pitchUp.IsOn()) {
			_pitchUpUI.SetActive(true);
			_rigidbody.AddRelativeTorque(-_pitchTorque, 0, 0);
			_thruster2.Play();
			_thruster4.Play();
			_thruster5.Play();
			_thruster7.Play();
		} else if ( _pitchDown.IsOn()) {
			_pitchDownUI.SetActive(true);
			_rigidbody.AddRelativeTorque(_pitchTorque, 0, 0);
			_thruster1.Play();
			_thruster3.Play();
			_thruster6.Play();
			_thruster8.Play();
		}

		_rigidbody.AddRelativeTorque( 0, 0, -_rollTorque * _rollAxis.GetState());
		if ( _rollAxis.GetState() > 0 ) {
			_rollUpUI.SetActive(true);
			_thruster2.Play();
			_thruster6.Play();
			_thruster3.Play();
			_thruster7.Play();
		} else if ( _rollAxis.GetState() < 0 ) {
			_rollDownUI.SetActive(true);
			_thruster1.Play();
			_thruster5.Play();
			_thruster4.Play();
			_thruster8.Play();
		}

		_rigidbody.AddRelativeTorque(0, _yawTorque * _yawAxis.GetState(), 0);
		if ( _yawAxis.GetState() > 0 ) {
			_yawRightUI.SetActive(true);
			_thruster1.Play();
			_thruster2.Play();
			_thruster7.Play();
			_thruster8.Play();
		} else if ( _yawAxis.GetState() < 0 ) {
			_yawLeftUI.SetActive(true);
			_thruster3.Play();
			_thruster4.Play();
			_thruster5.Play();
			_thruster6.Play();
		}

		if ( _panic.IsOn()) {
			_rigidbody.velocity = Vector3.Lerp( _rigidbody.velocity, Vector3.zero, _panicSpeed );
			_rigidbody.angularVelocity = Vector3.Lerp( _rigidbody.angularVelocity, Vector3.zero, _panicSpeed );

			_forwardAxis.Zero();
			_strafeAxis.Zero();
			_rollAxis.Zero();
			_yawAxis.Zero();
		}
	}

	public void StepBack() {
		_rigidbody.velocity = Vector3.Lerp( _rigidbody.velocity, Vector3.zero, _panicSpeed );
		_rigidbody.angularVelocity = Vector3.Lerp( _rigidbody.angularVelocity, Vector3.zero, _panicSpeed );

		_rigidbody.AddRelativeForce( Vector3.back * 25f);
		_strafeAxis.Zero();
		_rollAxis.Zero();
		_yawAxis.Zero();
	}
}
