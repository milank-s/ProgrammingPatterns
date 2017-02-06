using UnityEngine;
using System.Collections;

public class SpiralEnemy : Enemy {

	public SpiralEnemy(){
		
	}

	void Start(){
		_player = GameObject.Find ("Player");
		rb = GetComponent<Rigidbody2D> ();
	}

	void UpdateTargetPosition(){
		targetPosition = directionToPlayer + (Random.insideUnitCircle.normalized * 20);
	}

	void Shoot(){
	}

	protected void BehaviourLoop (){
		if (interval < 0) {
			Shoot ();
			interval = Random.Range(RoF, RoF*2);
		}
		else{
			Move ();
			UpdateTargetPosition ();
			UpdateDirection ();
			interval -= Time.deltaTime;
		} 
	}

	void FixedUpdate(){
		BehaviourLoop ();
	}
}
