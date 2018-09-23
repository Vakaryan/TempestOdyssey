using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAndButtonManager: MonoBehaviour {

	public enum MenuStates {Main, Levels, Tuto};
	public MenuStates currentState;
	public GameObject mainMenuPanel;
	public GameObject levelsMenuPanel;
	public GameObject tutoMenuPanel;



	void Awake(){
		currentState = MenuStates.Main;
	}


	void Update(){
		switch (currentState) {
		case MenuStates.Main:
			mainMenuPanel.SetActive (true);
			levelsMenuPanel.SetActive (false);
			tutoMenuPanel.SetActive (false);
			break;
		case MenuStates.Levels:
			levelsMenuPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
			tutoMenuPanel.SetActive (false);
			break;
		case MenuStates.Tuto:
			tutoMenuPanel.SetActive (true);
			mainMenuPanel.SetActive (false);
			levelsMenuPanel.SetActive (false);
			break;
		}
	}





	public void QuitGame(){
		Application.Quit ();
	}

	public void StartLevel(int idLvl){
		PlayerPrefs.SetInt ("Score", 0);
		SceneManager.LoadScene (idLvl);
	}


	public void ToLevelsMenu(){
		currentState = MenuStates.Levels;
	}

	public void ToMainMenu(){
		currentState = MenuStates.Main;
	}

	public void ToTutoMenu(){
		currentState = MenuStates.Tuto;
	}

	public void ToTitleScreen(){
		SceneManager.LoadScene (0);
		currentState = MenuStates.Main;
	}
}
