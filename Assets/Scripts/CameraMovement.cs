using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	private float currentMX = 0f;
    private float currentMY = 0f;
	private float xRotation = 0f;
    private float yRotation = 0f;
    private Quaternion initialRotation;
    private Quaternion cameraRotation;
    private float maxY = 0f;
    private float maxX = 0f;
    public float maxRotation = 50f;

	// Use this for initialization
	void Start () {
		currentMX = Input.mousePosition.x;
        currentMY = Input.mousePosition.y;
        initialRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		cameraRotation = transform.parent.rotation * initialRotation; 

		if (Input.GetMouseButton(1)) {
            currentMX = Input.mousePosition.x;
            currentMY = Input.mousePosition.y;

            if (Mathf.Abs(currentMX - Screen.currentResolution.width / 2) > maxX)
            {
                maxX = Mathf.Abs(currentMX - Screen.currentResolution.width / 2);
            }
            if (Mathf.Abs(currentMY - Screen.currentResolution.height / 2) > maxY)
            {
                maxY = Mathf.Abs(currentMY - Screen.currentResolution.height / 2);
            }

            yRotation = (currentMX - Screen.currentResolution.width / 2) * (maxRotation / Screen.currentResolution.width);
            xRotation = -(currentMY - Screen.currentResolution.height / 2) * (maxRotation / Screen.currentResolution.height);


            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(new Vector3(xRotation, yRotation, transform.rotation.z)), 7 * Time.deltaTime);
        } 
        else {
        	transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotation, 7 * Time.deltaTime);
        }
	}
}
