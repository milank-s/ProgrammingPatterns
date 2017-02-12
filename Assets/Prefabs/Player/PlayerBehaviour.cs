using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

	public int _health;

	bool isBehindCover = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Cover") {
			isBehindCover = true;
			_health++;
		}
	}

	public void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Cover") {
			isBehindCover = false;
		}
	}

	public bool getBehindCover(){
		return isBehindCover;
	}
}

