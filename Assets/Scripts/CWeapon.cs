using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWeapon : MonoBehaviour {

	public GameObject cWeapon;
	public GameObject newBullet;

	public Sprite Weapon2;

	public float newTimer;
	public float newLimitTimer;

	public int _Ammo;

	void OnTriggerEnter2D (Collider2D _col){
		if(_col.gameObject.CompareTag("Player")){

			cWeapon.GetComponent<Weapons> ().Ammo = _Ammo;
			
			if (_Ammo >= 1) {
				cWeapon.GetComponent<Weapons> ().Weapon = Weapon2;
				cWeapon.GetComponent<Weapons> ().Timer = newTimer;
				cWeapon.GetComponent<Weapons> ().LimitTimer = newLimitTimer;
				cWeapon.GetComponent<Weapons> ().Bullet = newBullet;
	
				Destroy (gameObject);
				_Ammo -= 1;
			} 
		}

	}
}
