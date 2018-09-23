using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEngine : MonoBehaviour {
	Rigidbody2D rb;
	private int dir = 1;
	private int delayZ = 0;


	void Awake(){
		rb = GetComponent<Rigidbody2D>();
	}


	void Start () {
		GetComponent<BulletGun> ().DirShoot = -1;
		if (GetComponent<EnemyAvatar>().CanShoot) {
			GetComponent<BulletGun> ().InvokeRepeating ("Shoot", GetComponent<EnemyAvatar> ().fireRate, GetComponent<EnemyAvatar> ().fireRate);
		}
	}

	void Update () {
		GetComponent<BulletGun> ().Shooting = false;
		if (GetComponent<EnemyAvatar>().zigzag) {
			rb.velocity = new Vector2 (GetComponent<EnemyAvatar>().MaxSpeed*-1, dir*GetComponent<EnemyAvatar>().YSpeed);
			delayZ++;
			if (delayZ > 200) {
				delayZ = 0;
				dir *= -1;
			}
		} else {
			rb.velocity = new Vector2 (GetComponent<EnemyAvatar>().MaxSpeed*-1, GetComponent<EnemyAvatar>().YSpeed);
		}
	}
}
