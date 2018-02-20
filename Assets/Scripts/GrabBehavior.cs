using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehavior : MonoBehaviour {

	RaycastHit hitInfo;
	Vector3 fwdPos;
	ParticleSystem beam;

	// Use this for initialization
	void Start () {
		beam = transform.GetChild(1).GetComponent<ParticleSystem> ();

	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (this.transform.position, this.transform.forward);
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 5.0f;

		if (Input.GetKeyDown ("t")) {
			Debug.Log ("on/off");
			if (beam.isPlaying) {
				beam.Stop ();
			} else {
				beam.Play ();
			}
		}
		// e for grabbing, r for pushing away
		if (Physics.Raycast (ray, out hitInfo, 100f) && beam.isPlaying) {

			if (hitInfo.collider.tag == "interactable") {

				if (Input.GetKey ("e")) {

					Debug.Log ("Grab");
					hitInfo.collider.transform.position = Vector3.Lerp (hitInfo.collider.transform.position, transform.position, 2 * Time.deltaTime);

				} else if (Input.GetKey ("r")) {

					Debug.Log ("Drop");
					fwdPos = transform.position + transform.forward * 30f;
					hitInfo.collider.transform.position = Vector3.Lerp (hitInfo.collider.transform.position, fwdPos, 1 * Time.deltaTime);

				}

			}
			
		}

		transform.Rotate (0, x, 0);
		transform.Translate (0, 0, z);


	}
}
