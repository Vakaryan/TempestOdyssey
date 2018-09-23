using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

	public float rateGlobal;
	public GameObject[] enemies;
	public int waves;
	public int bossDelay;
	public GameObject boss;
	public GameObject player;
	//public TextAsset levelDescriptionXML;
	//private int currentLvlID = -1;


	void Start () {
		Instantiate (player);
		/*if (bossDelay <= 0) {
			StartCoroutine (Waiter ());
			Instantiate (boss);
		*/
		InvokeRepeating ("SpawnEnemy", rateGlobal, rateGlobal);



		//List<Data.LevelDescription> level = XMlHelper.DeserializeDatabaseFromXML<Data.LevelDescription> (levelDescriptionXML);
		//StartNextLevel ();
	}


	void Update(){
		bossDelay--;
	}


	/*
	 void StartNextLevel(){
		currentLvlID++;
		//TODO : update current level
		//TODO : test if current is terminated and go to next
	}
	*/


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



	IEnumerator Waiter(){
		yield return new WaitForSeconds (7);
	}
}
