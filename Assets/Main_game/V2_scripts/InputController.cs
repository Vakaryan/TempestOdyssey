using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
	private int delayF = 0;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		delayF++;
		if (Input.GetKey (KeyCode.Space)) {
			GetComponent<BulletGun> ().Shoot ();
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			GetComponent<Engine> ().MoveUp ();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			GetComponent<Engine> ().MoveDown ();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			GetComponent<Engine> ().MoveLeft ();
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			GetComponent<Engine> ().MoveRight ();
		}
		if(Input.GetKey(KeyCode.Tab) && delayF > 50){
			GetComponent<Engine>().SwitchFire ();
			delayF = 0;
		}
	}
}
