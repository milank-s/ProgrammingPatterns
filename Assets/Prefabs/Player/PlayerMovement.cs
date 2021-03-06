﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public Transform cursor;
	public float cursorDistance;

	Rigidbody2D r;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
		UpdateCursor ();
	}

	void UpdateCursor(){
		if (Input.GetAxis ("HorizontalB") != 0 || Input.GetAxis ("VerticalB") != 0) {
			Vector3 cursorDirection = new Vector2 (Input.GetAxis ("HorizontalB"), Input.GetAxis ("VerticalB")).normalized;
			cursor.position = transform.position + (cursorDirection * cursorDistance);
		}
	}

	void Move(){

		Vector2 moveDir = new Vector2(Input.GetAxis ("HorizontalA"), Input.GetAxis ("VerticalA"));
		Vector3 newPos = transform.position;
	
//		foreach (Rigidbody2D rd in GetComponentsInChildren<Rigidbody2D>()) {
//			rd.AddRelativeForce (Vector2.right * Input.GetAxis ("HorizontalA") * speed);
//			rd.AddRelativeForce (Vector2.up * Input.GetAxis ("VerticalA") * speed);
//		}
		if (moveDir != Vector2.zero) {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, moveDir), rotationSpeed);
		}

		r.AddForce((Vector2.right * moveDir.x * speed) + (Vector2.up * moveDir.y * speed));

		transform.position = newPos;
	}
}
