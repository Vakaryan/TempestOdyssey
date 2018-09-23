using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuncMurere : MonoBehaviour {
	float timer = 0f;
	float realTimer = 0;
	float duration;


	void Start () {
		duration = GetComponent<ParticleSystem> ().main.duration;
	}

	void Update(){
		timer += Time.deltaTime;
		realTimer = timer % 60;
		if (realTimer >= duration) {
			Destroy (gameObject);
		}
	}

}
