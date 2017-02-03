using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	
	public Transform cursor;
	public float cursorDistance;
	public float force;
	public float RoF = 0.33f;
	public GameObject bullet;
	public float bulletSpeed = 10;
	public float shakeIntensity = 0.25f;

	float timer;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;	
		timer = RoF;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < 0 && Input.GetAxis("HorizontalA") != 0 | Input.GetAxis("VerticalA") != 0 && timer < 0	) {
			if(Input.GetButton("Fire1")){
				Shoot ();
				timer = RoF;
			}
		} else {
			timer -= Time.deltaTime;
		}

		UpdateCursor ();
	}

		//shoot

	void UpdateCursor(){
		Vector3 cursorDirection = new Vector2 (Input.GetAxis ("HorizontalA"), Input.GetAxis ("VerticalA")).normalized;
		cursor.position = transform.position + (cursorDirection * cursorDistance);
	}

	void Shoot(){

		Vector3 cursorDirection = new Vector2 (Input.GetAxis ("HorizontalA"), Input.GetAxis ("VerticalA"));

		float angle = Mathf.Atan2(cursorDirection.x, cursorDirection.y) * Mathf.Rad2Deg;

		GameObject newBullet = (GameObject)Instantiate(bullet, transform.position + cursorDirection - (transform.up * 1.5f),  Quaternion.Euler(new Vector3(0, 0, angle)));
		newBullet.GetComponent<Rigidbody2D> ().AddForce (cursorDirection* bulletSpeed);

		Camera.main.GetComponent<CameraControl> ().shakeTimer += Time.deltaTime;
		GetComponent<Rigidbody2D> ().AddForce (-cursorDirection * force);
	}
}
