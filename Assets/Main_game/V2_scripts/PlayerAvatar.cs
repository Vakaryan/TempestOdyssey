using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAvatar : BaseAvatar {
	public Slider healthbar;
	public Slider energybar;
	public Text noEnergyText;
	private int delayE = 0;
	public Sprite[] fireTypesIcons;
	public Image iconFireType;


	void Awake(){
		maxHealth = 20;
		maxEnergy = 30;
		maxSpeed = 40;
		curHealth = maxHealth;
		curEnergy = maxEnergy;
		fireType = ShootingTypes.StraightPlayer;
		dirBullets = 1;
		GetComponent<BulletGun> ().DirShoot = dirBullets;
		GetComponent<BulletGun> ().CurrentFire = fireType;
		GetComponent<Engine> ().Speed = maxSpeed;
		healthbar.value = CalculateHealth ();
		energybar.value = CalculateEnergy ();
		iconFireType.GetComponent<Image> ().sprite = fireTypesIcons [0];
	}


	void Start(){
		PlayerPrefs.SetInt ("Score", 0);
	}


	void Update(){
		healthbar.value = CalculateHealth ();
		if (GetComponent<BulletGun> ().Shooting) {
			switch (fireType) {
			case ShootingTypes.StraightPlayer:
				curEnergy -= 1;
				energybar.value = CalculateEnergy ();
				break;
			case ShootingTypes.DoubleAnglePlayer:
				curEnergy -= 1.5f;
				energybar.value = CalculateEnergy ();
				break;
			case ShootingTypes.VortexPlayer:
				curEnergy -= 2;
				energybar.value = CalculateEnergy ();
				break;
			}
			GetComponent<BulletGun> ().Shooting = false;
			if (curEnergy <= 0 && curEnergy != -10) {
				GetComponent<BulletGun> ().Dry = true;
			}
		}

		if (curEnergy < maxEnergy && delayE > 30) {
			delayE = 0;
			curEnergy+=1.5f;
			energybar.value = CalculateEnergy ();
		}
		if (GetComponent<BulletGun> ().Dry) {
			noEnergyText.text = "No energy left! Wait to reload it.";
			delayE++;
			if (curEnergy < maxEnergy && delayE > 35) {
				delayE = 0;
				curEnergy += 1f;
				energybar.value = CalculateEnergy ();
			}
			if (curEnergy >= maxEnergy) {
				GetComponent<BulletGun> ().Dry = false;
				noEnergyText.text = "";
			}
		} else {
			delayE++;
		}

	}

	public ShootingTypes FireType{
		get{
			return this.fireType;
		}
		set{
			this.fireType = value;
			GetComponent<BulletGun> ().CurrentFire = value;
			switch (value) {
			case ShootingTypes.StraightPlayer:
				iconFireType.GetComponent<Image> ().sprite = fireTypesIcons [0];
				break;
			case ShootingTypes.DoubleAnglePlayer:
				iconFireType.GetComponent<Image> ().sprite = fireTypesIcons [1];
				break;
			case ShootingTypes.VortexPlayer:
				iconFireType.GetComponent<Image> ().sprite = fireTypesIcons [2];
				break;
			}
		}
	}

	float CalculateHealth() {
		return curHealth / maxHealth;
	}

	float CalculateEnergy() {
		return curEnergy / maxEnergy;
	}

	public void AddHealth(int hp){
		curHealth += hp;
		healthbar.value = CalculateHealth ();
	}

	public void AddEnergy(int ep){
		curEnergy += ep;
		healthbar.value = CalculateEnergy ();
	}
}
