using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitReferences : MonoBehaviour {

	// Public variables
	[ SerializeField ]
	private Hand _hand;
	public Hand Hand { get { return _hand; }}

	[ SerializeField ]
	private TractorBeam _tractorBeam;
	public TractorBeam TractorBeam { get { return _tractorBeam; }}

	[ SerializeField ]
	private Movement _movement;
	public Movement Movement { get { return _movement; }}
}
