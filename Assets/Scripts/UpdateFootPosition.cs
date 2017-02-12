using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFootPosition : MonoBehaviour {

	public Rigidbody2D playerRigidbody;
	public float legLength;
	public float xOffset;
	public float directionOffset;
	public float maxDistance;
	public float lerpSpeed;
	public float updateInterval;
	public float timeOffset;

	public Sprite footprintSprite;

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
		moveDir = new Vector2 (playerRigidbody.velocity.normalized.x, playerRigidbody.velocity.normalized.y).normalized;
		Vector2 calculatedOffset = ((transform.right * offset.x) + (transform.up * offset.y)/2);
		newPosition = (Vector2)transform.parent.position;
		newPosition += ((moveDir * directionOffset) + (calculatedOffset * xOffset))* legLength;
		GameObject footprint = new GameObject ();
		footprint.transform.position = transform.position;
		footprint.AddComponent<SpriteRenderer> ().sprite = footprintSprite;
		footprint.AddComponent<FadeSprite> ();

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

			if (Vector3.Distance(transform.parent.position, lastUpdatedPosition) > maxDistance) {
				interval = 0;
				FindNewPosition ();
			}
		}
	}
}
