using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	[Header("Tuning")]
	public float _speed;
	public int _health;

	[Header("Prefabs")]
	public GameObject _bullet;

	[Header("Sounds")]

	public AudioSource shootSound;
	public AudioSource deathSound;

	protected GameObject _player;

	public Enemy(){
	}

	void Start(){
		_player = GameObject.Find("Player");
		//add required components e.g. "Movetowardsplayer" or "shootatPlayer"
	}

	protected virtual void Move(){
		//move towards player
	}

	protected virtual void Shoot(){
	}


	protected void Die(){
		
	}

	protected void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "bullet") {
			Destroy (gameObject);
		}
	}
}
