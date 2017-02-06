using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	[Header("Tuning")]
	public float _speed = 1;
	public int _health = 1;
	public float RoF = 1f;
	public float bulletSpeed;
	public float bulletForce;

	[Header("Prefabs")]
	public GameObject _bullet;

	[Header("Sounds")]

	public AudioSource shootSound;
	public AudioSource deathSound;

	protected static GameObject _player;
	protected Rigidbody2D rb;
	protected Vector2 directionToPlayer,targetPosition; 

	protected float interval;

	public Enemy(){
	}

	void Start(){
		//add required components e.g. "Movetowardsplayer" or "shootatPlayer"
		_player = GameObject.Find("Player");
		rb = this.GetComponent<Rigidbody2D> ();
	}

	protected void UpdateDirection(){
		directionToPlayer = (_player.transform.position - transform.position).normalized;
		Debug.DrawLine (transform.position, directionToPlayer);
	}

	protected void FacePlayer(){
		float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0, 0, angle);
	}

	protected void UpdateTargetPosition(){
	}

	protected void Move(){
		rb.AddForce(targetPosition.normalized * _speed);
	}

	protected void BehaviourLoop (){
		if (interval < 0) {
			Shoot ();
			interval = Random.Range(RoF, RoF*2);
		}
		else if (interval < RoF/2) {
			Move ();
			UpdateTargetPosition ();
			UpdateDirection ();
		} 

		interval -= Time.deltaTime;
	}

	protected void Shoot(){
		Vector3 direction = _player.transform.position - transform.position;
		direction = direction.normalized;

		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		GameObject newBullet = (GameObject)Instantiate(_bullet, this.transform.position,  Quaternion.Euler(new Vector3(0, 0, angle)));
		newBullet.GetComponent<Rigidbody2D> ().AddForce (direction * bulletSpeed);

		GetComponent<Rigidbody2D> ().AddForce (-direction * bulletForce);
	}


	protected void Die(){
		this.enabled = false;
		GetComponent<SpriteRenderer> ().color = new Color (0,0,0,0.5f);
		Camera.main.GetComponent<CameraControl> ().shakeTimer += Time.deltaTime * 5;
	}

	public void TakeDamage(){
		_health -= 1;
		Camera.main.GetComponent<CameraControl> ().shakeTimer += Time.deltaTime * 2;
		if (_health <= 0) {
			Die ();
		}
	}
}
