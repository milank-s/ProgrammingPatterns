using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {

	Rigidbody2D r;
	public float lifeTime = 1;
	private float time = 0;
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		r.AddRelativeForce (transform.right * (Mathf.Cos (time * 15) * 200));
//		!GetComponent<Renderer>().isVisible
		if (time > lifeTime) {
			Destroy (this.gameObject);
		}
	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<Enemy> ().TakeDamage ();
		}
		if (col.gameObject.tag == "Player") {
//			col.gameObject.GetComponent<PlayerStats> ().TakeDamage ();
		}
	}
}
