using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		Vector3 newPos = transform.position;
		if (Input.GetAxis ("Horizontal") < 0) {
			GetComponent<SpriteRenderer> ().flipX = true;
		} else if (Input.GetAxis ("Horizontal") > 0){
			GetComponent<SpriteRenderer> ().flipX = false;
		}

		newPos.x += Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		newPos.y += Input.GetAxis ("Vertical") * Time.deltaTime * speed;

		transform.position = newPos;
	}
}
