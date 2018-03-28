using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{

    // Exposed variables
    [Header("Movement forces")]
    [SerializeField]
    private float _translationForce;
    [SerializeField]
    private float _pitchTorque;
    [SerializeField]
    private float _rollTorque;
    [SerializeField]
    private float _yawTorque;
    [SerializeField]
    private float _panicSpeed;

    [Header("Movement buttons")]
    [SerializeField]
    private Control _forward;
    [SerializeField]
    private Control _backward;
    [SerializeField]
    private Control _strafeLeft;
    [SerializeField]
    private Control _strafeRight;
    [SerializeField]
    private Control _moveUp;
    [SerializeField]
    private Control _moveDown;

    [Space]
    [SerializeField]
    private Control _pitchUp;
    [SerializeField]
    private Control _pitchDown;
    [SerializeField]
    private Control _rollLeft;
    [SerializeField]
    private Control _rollRight;
    [SerializeField]
    private Control _yawLeft;
    [SerializeField]
    private Control _yawRight;

    [Space]
    [SerializeField]
    private Control _panic;
    [Space]

    [SerializeField]
    private GameObject _shoulder;
    [SerializeField]
    private GameObject _forearm;
    [SerializeField]
    private GameObject _hand;

    [Header("Thruster Particles")]
    [SerializeField]
    private ParticleSystem _thruster1;
    [SerializeField]
    private ParticleSystem _thruster2;
    [SerializeField]
    private ParticleSystem _thruster3;
    [SerializeField]
    private ParticleSystem _thruster4;
    [SerializeField]
    private ParticleSystem _thruster5;
    [SerializeField]
    private ParticleSystem _thruster6;
    [SerializeField]
    private ParticleSystem _thruster7;
    [SerializeField]
    private ParticleSystem _thruster8;
    

    private Rigidbody _shoulderbody;
    private Rigidbody _forearmbody;
    private Rigidbody _handbody;
    private Rigidbody _wristbody;

    // Private variables
    Rigidbody _rigidbody;


    // Messages
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _shoulderbody = _shoulder.GetComponent<Rigidbody>();
        _forearmbody = _forearm.GetComponent<Rigidbody>();
        _handbody = _hand.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _thruster1.Stop();
        _thruster2.Stop();
        _thruster3.Stop();
        _thruster4.Stop();
        _thruster5.Stop();
        _thruster6.Stop();
        _thruster7.Stop();
        _thruster8.Stop();
        if (_shoulder.GetComponent<shoulderBehavior>().use == false &&
            _forearm.GetComponent<forearmBehavior>().use == false){
            _shoulderbody.constraints = RigidbodyConstraints.FreezePosition;
            _forearmbody.constraints = RigidbodyConstraints.FreezePosition;
            _handbody.constraints = RigidbodyConstraints.FreezePosition;

			// _shoulderbody.constraints = RigidbodyConstraints.FreezeRotation;
			// _forearmbody.constraints = RigidbodyConstraints.FreezeRotation;
			// _handbody.constraints = RigidbodyConstraints.FreezeRotation;
			
        }
        else{
            _shoulderbody.constraints = RigidbodyConstraints.None;
            _forearmbody.constraints = RigidbodyConstraints.None;
            _handbody.constraints = RigidbodyConstraints.None;
        }
        if (_forward.IsOn())
        {
            _rigidbody.AddRelativeForce(Vector3.forward * _translationForce);
            _thruster5.Play();
            _thruster6.Play();
            _thruster7.Play();
            _thruster8.Play();
        }
        else if (_backward.IsOn())
        {
            _rigidbody.AddRelativeForce(Vector3.back * _translationForce);
            _thruster1.Play();
            _thruster2.Play();
            _thruster3.Play();
            _thruster4.Play();
        }

        if (_strafeLeft.IsOn())
        {
            _rigidbody.AddRelativeForce(Vector3.left * _translationForce);
            _thruster1.Play();
            _thruster2.Play();
            _thruster5.Play();
            _thruster6.Play();
        }
        else if (_strafeRight.IsOn())
        {
            _rigidbody.AddRelativeForce(Vector3.right * _translationForce);
            _thruster3.Play();
            _thruster4.Play();
            _thruster7.Play();
            _thruster8.Play();
        }

        if (_moveUp.IsOn())
        {
            _rigidbody.AddRelativeForce(Vector3.up * _translationForce);
            _thruster2.Play();
            _thruster4.Play();
            _thruster6.Play();
            _thruster8.Play();
        }
        else if (_moveDown.IsOn())
        {
            _rigidbody.AddRelativeForce(Vector3.down * _translationForce);
            _thruster1.Play();
            _thruster3.Play();
            _thruster5.Play();
            _thruster7.Play();
        }

        if (_pitchUp.IsOn())
        {
            _rigidbody.AddRelativeTorque(-_pitchTorque, 0, 0);
            _thruster2.Play();
            _thruster4.Play();
            _thruster5.Play();
            _thruster7.Play();
        }
        else if (_pitchDown.IsOn())
        {
            _rigidbody.AddRelativeTorque(_pitchTorque, 0, 0);
            _thruster1.Play();
            _thruster3.Play();
            _thruster6.Play();
            _thruster8.Play();
        }

        if (_rollLeft.IsOn())
        {
            _rigidbody.AddRelativeTorque(0, 0, _rollTorque);
            _thruster2.Play();
            _thruster6.Play();
            _thruster3.Play();
            _thruster7.Play();
        }
        else if (_rollRight.IsOn())
        {
            _rigidbody.AddRelativeTorque(0, 0, -_rollTorque);
            _thruster1.Play();
            _thruster5.Play();
            _thruster4.Play();
            _thruster8.Play();
        }

        if (_yawLeft.IsOn())
        {
            _rigidbody.AddRelativeTorque(0, -_yawTorque, 0);
            _thruster1.Play();
            _thruster2.Play();
            _thruster7.Play();
            _thruster8.Play();
        }
        else if (_yawRight.IsOn())
        {
            _rigidbody.AddRelativeTorque(0, _yawTorque, 0);
            _thruster3.Play();
            _thruster4.Play();
            _thruster5.Play();
            _thruster6.Play();
        }

        if (_panic.IsOn())
        {
            Vector3 rest = new Vector3(0, 0, 0);
            _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity, rest, _panicSpeed);
            _rigidbody.angularVelocity = Vector3.Lerp(_rigidbody.velocity, rest, _panicSpeed);
        }
    }
}
