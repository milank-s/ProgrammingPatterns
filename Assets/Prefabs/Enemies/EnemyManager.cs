using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject[] EnemyTypes;
	public float speed;

	private float interval;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (interval < 0) {
			SpawnEnemies ();
			interval = speed;
		} else {
			interval -= Time.deltaTime;
		}
	}

	void SpawnEnemies(){
		for (int i = 0; i < EnemyTypes.Length; i++){
			GameObject newEnemy = (GameObject)Instantiate (EnemyTypes[i], Random.insideUnitCircle.normalized * Camera.main.orthographicSize, Quaternion.identity);
		}
	}
}
