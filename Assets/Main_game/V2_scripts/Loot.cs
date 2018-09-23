using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

	public enum DropType {Health, Energy, Shield};
	public DropType curDrop;
	Rigidbody2D rb;

	public int amountHealthDrop;
	public int amountEnergyDrop;
	public int amountShieldDrop;

	public List<Sprite> spriteDrop;
	SpriteRenderer sp;

	public float speed;
	int dir = -1;


	void Awake(){
		rb = GetComponent<Rigidbody2D> ();

		int id = (int)Random.Range (0, 2); //Range(0,3) when shields implemented
		switch (id) {
		case 0:
			curDrop = DropType.Health;
			break;
		case 1:
			curDrop = DropType.Energy;
			break;
		case 2:
			curDrop = DropType.Shield;
			break;
		}
		sp = GetComponent<SpriteRenderer>();
		sp.sprite = spriteDrop [id];
	}


	void Update(){
		rb.velocity = new Vector2 (speed * dir, 0);
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Player touched");
			switch (curDrop) {
			case DropType.Health:
				col.gameObject.GetComponent<PlayerAvatar> ().AddHealth (amountHealthDrop);
				break;
			case DropType.Energy:
				col.gameObject.GetComponent<PlayerAvatar> ().AddEnergy (amountEnergyDrop);
				break;
			case DropType.Shield:
				//shield
				break;
			}
			Destroy (gameObject);
		}
	}
}
