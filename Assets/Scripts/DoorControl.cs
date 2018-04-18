using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {

    private Vector3 _doorPos;

    [SerializeField]
    private GameObject key1;
    [SerializeField]
    private GameObject key2;

    void Start()
    {
        _doorPos = transform.position;
    }

    void Update()
    {
        if(key1.GetComponent<SnapMovement2>().isSnapped() && key2.GetComponent<SnapMovement2>().isSnapped())
        {
            transform.position = Vector3.Lerp(transform.position, _doorPos + (transform.right * 3.5f), 0.10f);
        }
    }
}
