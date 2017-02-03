using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFootPosition : MonoBehaviour {

	public float legLength;
	public float xOffset;
	public float directionOffset;
	public float maxDistance;
	public float lerpSpeed;
	public float updateInterval;
	public float timeOffset;

	bool movingFoot = false;
	float interval; 

	Vector2 offset;
	Vector2 moveDir;
	Vector2 lastUpdatedPosition;
	Vector2 newPosition;
	// Use this for initialization
	void Start () {
		offset = transform.parent.localPosition.normalized;
		lastUpdatedPosition = transform.position;
		interval = updateInterval + timeOffset;
	}
	
	// Update is called once per frame
	void Update () {
		Step ();
	}

	void FindNewPosition(){
		movingFoot = true;
		moveDir = new Vector2 (Input.GetAxis ("HorizontalA"), Input.GetAxis ("VerticalA")).normalized;
		Vector2 calculatedOffset = ((transform.right * offset.x) + (transform.up * offset.y)/2);
		newPosition = (Vector2)transform.parent.position;
		newPosition += ((moveDir * directionOffset) + (calculatedOffset * xOffset))* legLength;
		Debug.Log (moveDir);
	}

	void Step(){
		if (movingFoot) {
			transform.position = Vector3.Lerp(lastUpdatedPosition, newPosition, interval);
			interval += Time.deltaTime * lerpSpeed;

			if (Vector3.Distance (transform.position, newPosition) <= 0.05f) {
				lastUpdatedPosition = newPosition;
				movingFoot = false;
				interval = updateInterval;
			}
		} else {
			transform.position = lastUpdatedPosition;
			interval -= Time.deltaTime;

			if (interval < 0 || Vector3.Distance(transform.parent.position, lastUpdatedPosition) > maxDistance) {
				interval = 0;
				FindNewPosition ();
			}
		}
	}
}
