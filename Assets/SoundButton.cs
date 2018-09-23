using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {
	public Button soundButton;
	public Sprite soundSprite;
	public Sprite nosoundSprite;
	public bool isActive;


	void Start(){
		if (AudioListener.volume > 0) {
			isActive = true;
			soundButton.GetComponent<Image> ().sprite = soundSprite;
		} else {
			isActive = false;
			soundButton.GetComponent<Image> ().sprite = nosoundSprite;
		}
	}

	public void SwitchSound(){
		if (isActive) {
			AudioListener.volume = 0f;
			soundButton.GetComponent<Image> ().sprite = nosoundSprite;
			isActive = false;
		} else {
			AudioListener.volume = 1f;
			soundButton.GetComponent<Image> ().sprite = soundSprite;
			isActive = true;
		}
	}

}
