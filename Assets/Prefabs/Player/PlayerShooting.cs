using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	
	public float force;
	public float RoF = 0.33f;
	public GameObject bullet;
	public float bulletSpeed = 10;
	public float shakeIntensity = 0.25f;

	private ParticleSystem.EmissionModule e;
	float timer;
	Vector3 cursorDirection;
	// Use this for initialization
	void Start () {
		e = GetComponentInChildren<ParticleSystem> ().emission;
		Cursor.visible = false;	
		timer = RoF;
	}
	
	// Update is called once per frame
	void Update () {
		cursorDirection = new Vector2 (Input.GetAxis ("HorizontalB"), Input.GetAxis ("VerticalB"));
		if (cursorDirection != Vector3.zero) {
			if (timer < 0) {
				e.enabled = true;
				Shoot ();
				timer = RoF;
			}
		} else {
			e.enabled = false;
		}
		timer -= Time.deltaTime;
	}

	void Shoot(){

		float angle = Mathf.Atan2(cursorDirection.x, cursorDirection.y) * Mathf.Rad2Deg;

		GameObject newBullet = (GameObject)Instantiate(bullet, transform.position + cursorDirection - (transform.up * 1.5f),  Quaternion.Euler(new Vector3(0, 0, angle)));
		newBullet.GetComponent<Rigidbody2D> ().AddForce (cursorDirection* bulletSpeed);

		Camera.main.GetComponent<CameraControl> ().shakeTimer += Time.deltaTime;
		GetComponent<Rigidbody2D> ().AddForce (-cursorDirection * force);
	}
}
