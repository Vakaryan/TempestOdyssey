using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	protected Rigidbody2D rb;
	public float Xspeed;
	public float Yspeed;
	protected int dir;


	void Update () {
		rb.velocity = new Vector2 (Xspeed * dir, Yspeed * dir);
	}
}
