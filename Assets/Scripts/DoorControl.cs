using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {

    [SerializeField]
    private GameObject _door;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "PowerCube")
        {
            _door.gameObject.SetActive(false);
        }
    }
}
