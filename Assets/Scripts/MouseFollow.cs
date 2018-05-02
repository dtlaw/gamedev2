using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseFollow : MonoBehaviour {
	[ SerializeField ]
	private Texture2D[] _smile;
    private CursorMode cursor = CursorMode.Auto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(mouse, out hit, 1000f)){
			if(hit.collider.gameObject.GetComponent<Button>() != null){
				Debug.Log("asdfasd");
				Cursor.SetCursor(_smile[0], Vector2.zero, cursor);
			}else{
				Cursor.SetCursor(null, Vector2.zero, cursor);
			}
		}
	}
}
