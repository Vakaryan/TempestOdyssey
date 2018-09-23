using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour {
	int delayD = 0; 
	Rigidbody2D rb;
	private float speed;
	public float Speed{
		get{
			return this.speed;
		}
		set{
			this.speed = value;
		}
	}
	float upCooler = 0.5f;
	int upCount = 0;
	float downCooler = 0.5f;
	int downCount = 0;
	float leftCooler = 0.5f;
	int leftCount = 0;
	float rightCooler = 0.5f;
	int rightCount = 0;
	public enum DodgeDirection {up, down, left, right};
	public Text dodgeNotif;
	public AudioSource dodgeSoundEffect;




	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		rb.velocity = new Vector3 (Input.GetAxis ("Horizontal") * speed, Input.GetAxis ("Vertical") * speed, 0);

		if (upCooler > 0) {
			upCooler -= Time.deltaTime;
		}
		else {
			upCount = 0;
		}
		if (downCooler > 0) {
			downCooler -= Time.deltaTime;
		}
		else {
			downCount = 0;
		}
		if (leftCooler > 0) {
			leftCooler -= Time.deltaTime;
		}
		else {
			leftCount = 0;
		}
		if (rightCooler > 0) {
			rightCooler -= Time.deltaTime;
		}
		else {
			rightCount = 0;
		}
		delayD++;
	}



	public void MoveUp(){
		if (upCooler > 0 && upCount == 1 && delayD > 50) {
			StartCoroutine(Dodge (DodgeDirection.up));
		} 
		else {
			upCooler = 0.5f;
			upCount++;
		}
	}

	public void MoveDown(){
		if (downCooler > 0 && downCount == 1 && delayD > 50) {
			StartCoroutine(Dodge (DodgeDirection.down));
		} else {
			downCooler = 0.5f;
			downCount++;
		}
	}

	public void MoveLeft(){
		if (leftCooler > 0 && leftCount == 1 && delayD > 50) {
			StartCoroutine(Dodge (DodgeDirection.left));
		} else {
			leftCooler = 0.5f;
			leftCount++;
		}
	}

	public void MoveRight(){
		if (rightCooler > 0 && rightCount == 1 && delayD > 50) {
			StartCoroutine(Dodge (DodgeDirection.right));
		} else {
			rightCooler = 0.5f;
			rightCount++;
		}
	}



	IEnumerator Dodge(DodgeDirection dir){
		Debug.Log ("Dodging");
		GetComponent<PlayerAvatar> ().Invincible = true;
		float timer = 0f;
		float maxTimer = 0.25f;
		delayD = 0;
		dodgeNotif.text = "DO A BARREL ROLL!!";
		dodgeSoundEffect.Play ();

		switch (dir) {
		//up
		case DodgeDirection.up:
			Debug.Log ("dodge up");
			GetComponent<PlayerAvatar>().CurEnergy -= 5;
			while (timer < maxTimer) {
				StartCoroutine (BlinkDodge ());
				rb.transform.Rotate (new Vector3 (0, 1440 * Time.deltaTime, 0));
				rb.transform.position = new Vector3 (transform.position.x, transform.position.y + speed * 0.75f * Time.deltaTime, 0);
				timer += Time.deltaTime;
				yield return null;
			}
			break;

		//down
		case DodgeDirection.down:
			Debug.Log ("dodge down");
			GetComponent<PlayerAvatar>().CurEnergy -= 5;
			while (timer < maxTimer) {
				StartCoroutine (BlinkDodge ());
				transform.Rotate (new Vector3 (0, -1440 * Time.deltaTime, 0));
				transform.position = new Vector3 (transform.position.x, transform.position.y - speed * 0.75f * Time.deltaTime, 0);
				timer += Time.deltaTime;
				yield return null;
			}
			break;

		//left
		case DodgeDirection.left:
			Debug.Log ("dodge left");
			GetComponent<PlayerAvatar>().CurEnergy -= 5;
			while (timer < maxTimer) {
				StartCoroutine (BlinkDodge ());
				transform.Rotate (new Vector3 (-1440 * Time.deltaTime, 0, 0));
				transform.position = new Vector3 (transform.position.x - speed * 0.5f * Time.deltaTime, transform.position.y, 0);
				timer += Time.deltaTime;
				yield return null;
			}
			break;

		//right
		case DodgeDirection.right:
			Debug.Log ("dodge right");
			GetComponent<PlayerAvatar>().CurEnergy -= 5;
			while (timer < maxTimer) {
				StartCoroutine (BlinkDodge ());
				transform.Rotate (new Vector3 (1440 * Time.deltaTime, 0, 0));
				transform.position = new Vector3 (transform.position.x + speed * 0.5f * Time.deltaTime, transform.position.y, 0);
				timer += Time.deltaTime;
				yield return null;
			}
			break;

		}
		timer = 0f;
		yield return new WaitForSeconds (0.2f);
		GetComponent<PlayerAvatar> ().Invincible = false;
		dodgeNotif.text = "";
	}

	IEnumerator BlinkDodge(){
		GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0);
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
	}


	public void SwitchFire(){
		switch (GetComponent<PlayerAvatar>().FireType) {
		case BaseAvatar.ShootingTypes.StraightPlayer:
			GetComponent<PlayerAvatar>().FireType = BaseAvatar.ShootingTypes.DoubleAnglePlayer;
			break;
		case BaseAvatar.ShootingTypes.DoubleAnglePlayer:
			GetComponent<PlayerAvatar>().FireType = BaseAvatar.ShootingTypes.VortexPlayer;
			break;
		case BaseAvatar.ShootingTypes.VortexPlayer:
			GetComponent<PlayerAvatar>().FireType = BaseAvatar.ShootingTypes.StraightPlayer;
			break;
		}
		Debug.Log ("Fire type = " + GetComponent<PlayerAvatar>().FireType.ToString ());
	}
}
