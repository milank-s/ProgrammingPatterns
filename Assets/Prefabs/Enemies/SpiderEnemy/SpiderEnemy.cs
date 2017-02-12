using UnityEngine;
using System.Collections;

public class SpiderEnemy : Enemy {


	public SpiderEnemy(){
	}


	void Start(){
		_player = GameObject.Find ("Player");
		rb = GetComponent<Rigidbody2D> ();
	}

	new void UpdateTargetPosition(){
		Vector3 side = Vector3.Cross(directionToPlayer, Vector3.forward); //90 degrees (normalvector) to the plane closed by the forward and the dir vectors
		targetPosition =  (Vector2)(Mathf.Sign(Mathf.Sin(Time.time)) *_speed * side + transform.position) -(Vector2)directionToPlayer;
		rb.AddForce (directionToPlayer * 100);
	}
		
	new void BehaviourLoop (){
		if (interval < 0) {
			Shoot ();
			interval = Random.Range(RoF, RoF*2);
		}
		else if (interval < RoF/2) {
			Move ();
			UpdateTargetPosition ();
			UpdateDirection ();
			FacePlayer ();
		} 

		interval -= Time.deltaTime;
	}
		
	void FixedUpdate(){
		BehaviourLoop ();
	}
}