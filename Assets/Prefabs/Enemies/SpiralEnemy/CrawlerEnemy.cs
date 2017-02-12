using UnityEngine;
using System.Collections;

public class CrawlerEnemy : Enemy {

	public CrawlerEnemy(){
		
	}

	Vector2 RandomPos;

	void Start(){
		_player = GameObject.Find ("Player");
		rb = GetComponent<Rigidbody2D> ();
	}

	new void UpdateTargetPosition(){
		if (_player.GetComponent<PlayerBehaviour> ().getBehindCover()) {
			targetPosition = directionToPlayer;
		} else {
			targetPosition = RandomPos;
		}
	}

	new void Shoot(){
	}

	new protected void BehaviourLoop (){
		if (interval < 0) {
			Shoot ();
			interval = Random.Range(RoF, RoF*2);
			RandomPos = Random.insideUnitCircle.normalized * 10;
		}
		else{
			Move ();
			UpdateDirection ();
			UpdateTargetPosition ();
			interval -= Time.deltaTime;
		} 
	}

	void FixedUpdate(){
		BehaviourLoop ();
	}
}
