using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour {
	public GameObject[] bulletsObjects;
	public static BulletFactory Instance{ get; private set; }
	private List<GameObject>[] currentBullets;

	void Awake(){
		Debug.Assert (BulletFactory.Instance == null);
		BulletFactory.Instance = this;
	}


	public GameObject GetBullet(BulletType.BulletTypes type){
		GameObject bullet = null;
		switch (type) {
		case BulletType.BulletTypes.StraightPlayer:
			bullet = GameObject.Instantiate(bulletsObjects [(int)BulletType.BulletTypes.StraightPlayer]);
			break;
		case BulletType.BulletTypes.DoubleAnglePlayerL:
			bullet = GameObject.Instantiate(bulletsObjects [(int)BulletType.BulletTypes.DoubleAnglePlayerL]);
			break;
		case BulletType.BulletTypes.DoubleAnglePlayerR:
			bullet = GameObject.Instantiate(bulletsObjects [(int)BulletType.BulletTypes.DoubleAnglePlayerR]);
			break;
		case BulletType.BulletTypes.VortexPlayer:
			bullet = GameObject.Instantiate(bulletsObjects [(int)BulletType.BulletTypes.VortexPlayer]);
			break;
		case BulletType.BulletTypes.StraightEnemy:
			bullet = GameObject.Instantiate(bulletsObjects [(int)BulletType.BulletTypes.StraightEnemy]);
			break;
		case BulletType.BulletTypes.DoubleAngleEnemyL:
			bullet = GameObject.Instantiate(bulletsObjects [(int)BulletType.BulletTypes.DoubleAngleEnemyL]);
			break;
		case BulletType.BulletTypes.DoubleAngleEnemyR:
			bullet = GameObject.Instantiate(bulletsObjects [(int)BulletType.BulletTypes.DoubleAngleEnemyR]);
			break;
		case BulletType.BulletTypes.VortexEnemy:
			bullet = GameObject.Instantiate(bulletsObjects [(int)BulletType.BulletTypes.VortexEnemy]);
			break;
		}
		return bullet;
	}

}
