using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseFollow : MonoBehaviour {
	[ SerializeField ]
	private Texture2D[] _icons;
    private CursorMode cursor = CursorMode.ForceSoftware;
	private int _borderx;
	private int _bordery;
	// Use this for initialization
	void Start () {
		_borderx = Screen.width/4;
		_bordery = Screen.height/2;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.mousePosition.x >= Screen.width - _borderx ||
			Input.mousePosition.y >= Screen.height - _bordery||
			Input.mousePosition.x <= _borderx){
				Cursor.SetCursor(_icons[3], Vector2.zero, cursor);
		}else{
			Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(mouse, out hit, 1000f)){
				if(hit.collider.gameObject.GetComponent<Button>() != null ||
					hit.collider.gameObject.GetComponent<TwoPositionSwitch>() != null){
					Cursor.SetCursor(_icons[0], Vector2.zero, cursor);
				}else if(hit.collider.gameObject.GetComponent<Knob>() != null){
						Cursor.SetCursor(_icons[1], Vector2.zero, cursor);
				}else if(hit.collider.gameObject.GetComponent<Lever>() != null){
					if(!hit.collider.gameObject.GetComponent<Lever>().gripped()){
						Cursor.SetCursor(_icons[2], Vector2.zero, cursor);
					}
				}else{
					Cursor.SetCursor(null, Vector2.zero, cursor);
			}
		}
		}
	}
}
