using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet {


	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
		dir = 1;
	}

	void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Enemy") {
				col.gameObject.GetComponent<EnemyAvatar> ().Damage ();
				Destroy (transform.parent.gameObject);
			}
		}
}
