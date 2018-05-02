using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMovement : MonoBehaviour {
	private Vector3[] _doorPositions;
	[ SerializeField ]
	private GameObject[] goals;

	[ SerializeField ]
	private GameObject[] doors;

    private Hand _hand;
    private TractorBeam _beam;
    private bool snapped;
    private int index;
    Vector3 oldPos;
    Vector3 newPos;
	// Use this for initialization
	void Start () {
        _doorPositions = new Vector3[doors.Length];
        for(int i = 0; i < doors.Length; i++)
        {
            _doorPositions[i] = doors[i].transform.position;
        }
        _hand = GameManager.Instance.GetComponent<CockpitReferences>().Hand;
        _beam = GameManager.Instance.GetComponent<CockpitReferences>().TractorBeam;
        snapped = false;
        index = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (snapped)
        {
            if (_hand.Grabbing || _beam.Grabbing) {
                snapped = false;
                doors[index].transform.position = oldPos;
            }
        }
        if (!snapped)
        {   
            for(int i = 0; i < doors.Length; i++)
            {
                if (Vector3.Distance(this.transform.position, goals[i].transform.position) <= 1.3)
                {
                    if (!_hand.Grabbing && !_beam.Grabbing)
                    {
                        index = i;
                        snapped = true;
                        transform.rotation = Quaternion.Euler(new Vector3(goals[index].transform.rotation.eulerAngles.x, goals[index].transform.rotation.eulerAngles.y, goals[index].transform.rotation.eulerAngles.z));
                        transform.position = Vector3.Lerp(transform.position, goals[index].transform.position, Time.time);
                        newPos = doors[index].transform.position + (doors[index].transform.right * 3.5f);
                        oldPos = doors[index].transform.position;
                        //doors[index].transform.position = Vector3.Lerp(doors[index].transform.position, newPos, 0.01f);
                        doors[index].transform.position = newPos;
                    }
                }
            }
        }
    }
}
