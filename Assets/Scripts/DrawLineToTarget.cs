using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawLineToTarget : MonoBehaviour {

	LineRenderer l;
	public Transform target; 
	// Use this for initialization
	void Start () {
		l = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		l.SetPosition (0, transform.position);
		l.SetPosition (1, target.position);
	}
}
