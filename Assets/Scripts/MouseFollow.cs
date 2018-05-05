using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseFollow : MonoBehaviour {
	[ SerializeField ]
	private Texture2D[] _icons;
    private CursorMode cursor = CursorMode.ForceSoftware;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(mouse, out hit, 1000f)){
			if(hit.collider.gameObject.GetComponent<Button>() != null ||
				hit.collider.gameObject.GetComponent<TwoPositionSwitch>() != null){
				Cursor.SetCursor(_icons[0], new Vector2(16, 16), cursor);
			}else if(hit.collider.gameObject.GetComponent<Knob>() != null){
					Cursor.SetCursor(_icons[1],  new Vector2(16, 16), cursor);
			}else if(hit.collider.gameObject.GetComponent<Lever>() != null){
				if(!hit.collider.gameObject.GetComponent<Lever>().gripped()){
					Cursor.SetCursor(_icons[2],  new Vector2(16, 16), cursor);
				}
			}else{
				Cursor.SetCursor(null, Vector2.zero, cursor);
			}
		}
	}

	void OnMouseDown(){

	}
}
