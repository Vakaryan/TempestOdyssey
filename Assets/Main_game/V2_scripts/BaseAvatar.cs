using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAvatar : MonoBehaviour {
	protected float maxHealth;
	protected float curHealth;
	protected float maxEnergy;
	protected float curEnergy;
	protected float maxSpeed;
	protected int dirBullets;
	public enum ShootingTypes {StraightPlayer, DoubleAnglePlayer, VortexPlayer, StraightEnemy, DoubleAngleEnemy, VortexEnemy, None};
	protected ShootingTypes fireType;
	public GameObject explosion;
	protected bool invincible = false;
	protected bool murdered = false;

	public float MaxHealth{
		get{
			return this.maxHealth;
		}
		set{
			this.maxHealth = value;
		}
	}

	public float CurHealth{
		get{
			return this.curHealth;
		}
		set{
			this.curHealth = value;
		}
	}

	public float MaxEnergy{
		get{
			return this.maxEnergy;
		}
		set{
			this.maxEnergy = value;
		}
	}

	public float CurEnergy{
		get{
			return this.curEnergy;
		}
		set{
			this.curEnergy = value;
		}
	}

	public float MaxSpeed {
		get{
			return this.maxSpeed;
		}
		set{
			this.maxSpeed = value;
		}
	}

	public int DirBullets{
		get{
			return this.dirBullets;
		}
		set{
			this.dirBullets = value;
		}
	}


	public bool Invincible{
		get{
			return this.invincible;
		}
		set{
			this.invincible = value;
		}
	}

	public ShootingTypes FireType {
		get {
			return this.fireType;
		}
		set {
			this.fireType = value;
		}
	}


	public void Damage(){
		if (!invincible) {
			curHealth--;
			StartCoroutine (BlinkDeath ());
			if (curHealth == 0) {
				murdered = true;
				Die ();
			}
		}
	}

	public void Die() {
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	IEnumerator BlinkDeath (){
		GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
	}


}
