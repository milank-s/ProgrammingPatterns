using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public float RoF = 0.33f;
	public GameObject bullet;
	public float bulletSpeed = 10;
	public float shakeIntensity = 0.25f;

	float timer;
	// Use this for initialization
	void Start () {
		timer = RoF;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && timer < 0) {
			Shoot ();
			timer = RoF;
		} else {
			timer -= Time.deltaTime;
		}
	}

	void Shoot(){

		Vector3 cursorPos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
		Vector3 distanceToCursor = cursorPos -transform.position;
		distanceToCursor.Normalize ();

		float angle = Mathf.Atan2(-distanceToCursor.x, distanceToCursor.y) * Mathf.Rad2Deg;

		GameObject newBullet = (GameObject)Instantiate(bullet, transform.position + distanceToCursor - (transform.up * 1.5f),  Quaternion.Euler(new Vector3(0, 0, angle)));
		newBullet.GetComponent<Rigidbody2D> ().AddForce (distanceToCursor * bulletSpeed);

		Camera.main.GetComponent<CameraControl> ().shakeTimer += Time.deltaTime;
	}
}
