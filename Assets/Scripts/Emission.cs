using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission : MonoBehaviour {
	private Material[] _materials;
	private Hand _hand;
    private TractorBeam _beam;
    private bool _pickedUp;
    private bool _canPlace;
    private int _count;

    [SerializeField]
    private GameObject _trans;

	// Use this for initialization
	void Start () {
		_pickedUp = false;
        _canPlace = false;
		_hand = GameManager.Instance.GetComponent<CockpitReferences>().Hand;
        _beam = GameManager.Instance.GetComponent<CockpitReferences>().TractorBeam;
		_materials = GetComponent<Renderer>().materials;
		_count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (_hand.Grabbing || _beam.Grabbing) {
            if(_count == 0)
            {
                _pickedUp = true;
            }
        }
        else{
            _count = 0;
        }
        
        if (Vector3.Distance(_trans.transform.position, this.transform.position) <= 1.3){
            _canPlace = true;
        }
        else{
            _canPlace = false;
        }

		if (_pickedUp) {
			if (_count < 25 || (_count >= 50 && _count < 75) || (_count >= 100 && _count < 125) ) {
				_materials[0].EnableKeyword ("_EMISSION");
			} else {
				_materials[0].DisableKeyword ("_EMISSION");
			}
			_count += 1;
            if (_count > 125){
                _pickedUp = false;
            }
        }
        else if (_canPlace){
            if (_trans.transform.position == this.transform.position){
                _materials[0].DisableKeyword("_EMISSION");
            }
            else{
                _materials[0].EnableKeyword("_EMISSION");
            }
        }
        else{
            _materials[0].DisableKeyword("_EMISSION");
        }
    }
}
