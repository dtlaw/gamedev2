using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission : MonoBehaviour {
	private Material[] _materials;
	private Hand _hand;
    private TractorBeam _beam;
    private bool _blinking;
    private int _count;

	// Use this for initialization
	void Start () {
		_blinking = false;
		_hand = GameManager.Instance.GetComponent<CockpitReferences>().Hand;
        _beam = GameManager.Instance.GetComponent<CockpitReferences>().TractorBeam;
		_materials = GetComponent<Renderer>().materials;
		_count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (_hand.Grabbing || _beam.Grabbing) {
			_blinking = true;
		}
		if (_blinking) {
			if (_count < 25 || (_count >= 50 && _count < 75) || (_count >= 100 && _count < 125) ) {
				_materials[0].EnableKeyword ("_EMISSION");
			} else {
				_materials[0].DisableKeyword ("_EMISSION");
			}
			_count += 1;
		}
		
	}
}
