using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SimpleManager.Manager<Enemy>{

	public GameObject[] EnemyTypes;
	public float speed;

	private float interval;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (interval < 0) {
			Create ();
			interval = speed;
		} else {
			interval -= Time.deltaTime;
		}
	}

	public override Enemy Create(){
		Enemy newEnemy = Instantiate (EnemyTypes[0], (Vector2)GameObject.Find("Player").transform.position + (Random.insideUnitCircle.normalized * Camera.main.orthographicSize), Quaternion.identity).GetComponent<Enemy>();
		ManagedObjects.Add(newEnemy);
		return newEnemy;
	}

	public override void Destroy(Enemy e){
		ManagedObjects.Remove (e);
	}
}
