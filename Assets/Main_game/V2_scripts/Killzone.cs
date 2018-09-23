using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Bullet") {
			Destroy (col.transform.parent.gameObject);
		}
		else {
			Destroy (col.gameObject);
		}
	}
}
