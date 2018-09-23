using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour {

	GameObject lg,rg, mg;
	int delayS = 0;
	private BaseAvatar.ShootingTypes currentFire;
	public BaseAvatar.ShootingTypes CurrentFire {
		get {
			return this.currentFire;
		}
		set {
			this.currentFire = value;
		}
	}
	private bool shooting; 
	public bool Shooting{
		get{
			return this.shooting;
		}
		set{
			this.shooting = value;
		}
	}
	private int dirShoot;
	public int DirShoot{
		get{
			return this.dirShoot;
		}
		set{
			this.dirShoot = value;
		}
	}
	protected bool dry = false;
	public bool Dry {
		get {
			return this.dry;
		}
		set {
			this.dry = value;
		}
	}


	void Awake () {
		lg = transform.Find ("GunL").gameObject;
		rg = transform.Find ("GunR").gameObject;
		mg = transform.Find ("GunM").gameObject;
	}


	void Start(){
		shooting = false;
	}

	void Update () {
		if (!dry) {
			delayS++;
		}
	}


	public void Shoot(){
		if (!dry && delayS >= 15 && !shooting) {
			shooting = true;
			delayS = 0;
			GameObject bullet1;
			GameObject bullet2;
			GameObject bullet3;

			switch (currentFire) {

			case BaseAvatar.ShootingTypes.StraightPlayer:
				bullet1 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.StraightPlayer);
				bullet2 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.StraightPlayer);
				bullet1.transform.position = lg.transform.position;
				bullet2.transform.position = rg.transform.position;
				break;

			case BaseAvatar.ShootingTypes.DoubleAnglePlayer:
				bullet1 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.DoubleAnglePlayerL);
				bullet2 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.DoubleAnglePlayerR);
				bullet3 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.StraightPlayer);
				bullet1.transform.position = lg.transform.position;
				bullet2.transform.position = rg.transform.position;
				bullet3.transform.position = mg.transform.position;
				break;

			case BaseAvatar.ShootingTypes.VortexPlayer:
				bullet3 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.VortexPlayer);
				bullet3.transform.position = mg.transform.position;
				break;

			case BaseAvatar.ShootingTypes.StraightEnemy:
				bullet1 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.StraightEnemy);
				bullet2 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.StraightEnemy);
				bullet1.transform.position = lg.transform.position;
				bullet2.transform.position = rg.transform.position;
				break;

			case BaseAvatar.ShootingTypes.DoubleAngleEnemy:
				bullet1 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.DoubleAngleEnemyL);
				bullet2 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.DoubleAngleEnemyR);
				bullet1.transform.position = rg.transform.position;
				bullet2.transform.position = lg.transform.position;
				break;

			case BaseAvatar.ShootingTypes.VortexEnemy:
				bullet3 = BulletFactory.Instance.GetBullet (BulletType.BulletTypes.VortexEnemy);
				bullet3.transform.position = mg.transform.position;
				break;

			}
		}

	}
}
