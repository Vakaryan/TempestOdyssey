using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : BaseAvatar {
	public enum EnemyClass {DPS, Fast, Special, Tank};
	public EnemyClass enemyClass;
	private bool canShoot;
	public float fireRate;
	public bool zigzag;
	private float ySpeed;
	public int scorePoints;
	public float spawnRate;
	public float dropRate;
	public GameObject drop;


	void Awake(){
		switch (enemyClass) {
		case EnemyClass.DPS: 
			canShoot = true;
			maxHealth = 10;
			maxEnergy = -10;
			maxSpeed = 20;
			fireType = ShootingTypes.DoubleAngleEnemy;
			GetComponent<BulletGun> ().CurrentFire = ShootingTypes.DoubleAngleEnemy;
			ySpeed = 1.5f;
			break;

		case EnemyClass.Fast: 
			canShoot = false;
			maxHealth = 4;
			maxEnergy = -10;
			maxSpeed = 40;
			fireType = ShootingTypes.None;
			GetComponent<BulletGun> ().CurrentFire = ShootingTypes.None;
			break;

		case EnemyClass.Special: 
			canShoot = true;
			maxHealth = 12;
			maxEnergy = -10;
			maxSpeed = 10;
			fireType = ShootingTypes.StraightEnemy;
			GetComponent<BulletGun> ().CurrentFire = ShootingTypes.StraightEnemy;
			ySpeed = 7.5f;
			break;

		case EnemyClass.Tank: 
			canShoot = true;
			maxHealth = 15;
			maxEnergy = -1;
			maxSpeed = 15;
			fireType = ShootingTypes.StraightEnemy;
			GetComponent<BulletGun> ().CurrentFire = ShootingTypes.StraightEnemy;
			break;
		}
		curHealth = maxHealth;
		curEnergy = maxEnergy;
		dirBullets = -1;
	}

	public bool CanShoot{
		get{
			return this.canShoot;
		}
		set{
			this.canShoot = value;
		}
	}

	public float YSpeed {
		get {
			return this.ySpeed;
		}
		set {
			this.ySpeed = value;
		}
	}
		


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player" && !col.gameObject.GetComponent<PlayerAvatar>().Invincible) {
			col.gameObject.GetComponent<PlayerAvatar> ().Damage ();
			murdered = true;
			Die ();
		}
	}

	void OnDestroy(){
		if (murdered) {
			PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + scorePoints);
		}
		if (dropRate != 0 && murdered) {
			if (Random.value < dropRate) {
				Instantiate (drop, transform.position, Quaternion.identity);
			}
		}
	}

}
