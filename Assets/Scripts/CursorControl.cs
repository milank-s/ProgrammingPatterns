using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {

	LineRenderer l;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;	
	}
	
	// Update is called once per frame
	void Update () {
		MoveMouse();
	}
		
	void MoveMouse(){
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)); ;

	}
}
