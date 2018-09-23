using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine_endless : MonoBehaviour {
	public float rateGlobal;
	public GameObject[] enemies;
	public int waves;
	GameObject[] roster = new GameObject[4]; //current enemy roster
	int curWave;
	public float waveTime;
	float countdown;
	public GameObject player;


	void Start () {
	Instantiate (player);
		for (int i = 0; i < roster.Length; i++) {
			roster [i] = enemies [i];
		}
		countdown = waveTime;
		curWave = 1;
		InvokeRepeating("SpawnEnemy", rateGlobal, rateGlobal);
	}



	void Update(){
		countdown -= Time.deltaTime;
		if (countdown <= 0 && curWave < 4) {
			for (int i = 0; i < roster.Length; i++) {
				roster [i] = enemies [i+roster.Length*curWave];
			}
			curWave++;
			countdown = curWave * waveTime;
			Debug.Log ("New wave n° " + curWave.ToString ());
		}
		if (curWave == 3) {
			waves = 2;
		}
	}



	void SpawnEnemy () {
		int timer = 0;
		int idShip = -1;
		for (int i = 0; i < waves; i++) {
			idShip = RandShipID (enemies);
			Debug.Log ("IDship = " + idShip);
			if (idShip != -1) {
				GameObject spawnEnemy = enemies [idShip];
				Instantiate (spawnEnemy, new Vector3 (40f, Random.Range (-16f, 16f), 0f), Quaternion.identity);
			}
		}
	}




	int RandShipID(GameObject[] enemiesTab) {
		if (enemiesTab.Length == 0) {
			return -1;
		}
		if (enemiesTab.Length == 1) {
			return 0;
		}
		float rand = 0f;
		int i = 0;
		int idShip = -1;
		while (i < enemiesTab.Length && idShip == -1) {
			rand = Random.value;
			if (rand < enemiesTab [i].GetComponent<EnemyAvatar> ().spawnRate) {
				idShip = i;
			}
			i++;
		}

		return idShip;
	}

}
