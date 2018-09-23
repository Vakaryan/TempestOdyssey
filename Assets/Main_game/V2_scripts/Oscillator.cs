using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {
	float timeCount;
	float horizMove;
	public float speed;
	public float radius;
	public Vector2 origin;

	void Start(){
		origin = new Vector2 (transform.position.x, transform.position.y);
	}


	void Update () {
		timeCount += Time.deltaTime * speed;
		horizMove += Time.deltaTime * GetComponent<Bullet>().Xspeed;
		transform.position = new Vector2 (Mathf.Sin (timeCount) * radius + horizMove + origin.x, Mathf.Cos(timeCount) * radius + origin.y);
	}

}
