using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Static variables
	private static GameManager _instance;
	public static GameManager Instance { get { return _instance; }}


	// Messages
	private void Awake() {
		if ( _instance == null ) {
			_instance = this;
			DontDestroyOnLoad( this );
		} else {
			Destroy( this );
		}
	}
}
