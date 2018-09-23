using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet {

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		dir = -1;
	}

	void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				col.gameObject.GetComponent<PlayerAvatar> ().Damage ();
				Destroy (transform.parent.gameObject);
			}
		}
}
