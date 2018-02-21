using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {

    [SerializeField]
    private GameObject _door;

    private void OnCollisionEnter(Collision collision)
    {
        _door.gameObject.SetActive(false);
    }
}
