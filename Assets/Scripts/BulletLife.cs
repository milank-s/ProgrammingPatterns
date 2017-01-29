using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {

	Rigidbody2D r;
	public float lifeTime = 2;
	float time = 0;
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		r.AddRelativeForce(Vector2.right * (Mathf.Cos (time * 15) * 200));

		if (lifeTime > 0) {
			lifeTime -= Time.deltaTime;
		} else {
			Destroy (this.gameObject);
		}
	}
}
