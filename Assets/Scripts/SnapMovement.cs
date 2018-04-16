﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMovement : MonoBehaviour {
	private Vector3 _doorPos;
	[ SerializeField ]
	private GameObject goal;

	[ SerializeField ]
	private GameObject door;
	// Use this for initialization
	void Start () {
		_doorPos = door.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(transform.position, goal.transform.position) <= 0.6)
        {
            if (!GameObject.Find("Hand").GetComponent<handBehavior>().Grab())
            {
                transform.rotation = Quaternion.Euler(new Vector3(goal.transform.rotation.eulerAngles.x, goal.transform.rotation.eulerAngles.y, goal.transform.rotation.eulerAngles.z));
                transform.position = Vector3.Lerp(transform.position, goal.transform.position, Time.time);
                door.transform.position = Vector3.Lerp(door.transform.position, _doorPos + (door.transform.right * 3.5f), 0.10f);
            }
            else
            {
                door.transform.position = Vector3.Lerp(door.transform.position, _doorPos, 0.10f);
            }
        }
    }
}
