using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour {

	GameObject player;
	bool gameOver = false;
	public Text gameOverText;
	public int lvl; //lvl4 = endless


	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		lvl = SceneManager.GetActiveScene().buildIndex;
	}

	void Update () {
		if (player == null && !gameOver) {
			GameOver ();
		}
	}


	void GameOver(){
		gameOver = true;
		StartCoroutine (LoadGameOver ());
	}


	IEnumerator LoadGameOver(){
		yield return new WaitForSeconds (1.5f);
		gameOverText.text = "Y O U  D I E D";
		yield return new WaitForSeconds (4f);
		switch(lvl){
		case 1:
			if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScoreLVL1")) {
				PlayerPrefs.SetInt ("HighScoreLVL1", PlayerPrefs.GetInt ("Score"));
			}
			break;
		case 2:
			if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScoreLVL2")) {
				PlayerPrefs.SetInt ("HighScoreLVL2", PlayerPrefs.GetInt ("Score"));
			}
			break;
		case 3:
			if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScoreLVL3")) {
				PlayerPrefs.SetInt ("HighScoreLVL3", PlayerPrefs.GetInt ("Score"));
			}
			break;
		case 4:
			if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScoreEndless")) {
				PlayerPrefs.SetInt ("HighScoreEndless", PlayerPrefs.GetInt ("Score"));
			}
			break;
		}
		SceneManager.LoadScene ("end_game");
	}

}
