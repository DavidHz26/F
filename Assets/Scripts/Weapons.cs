using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

	public int Direction;
	public float Speed;
	public int Ammo;

	public GameObject Bullet;
	GameObject actualBullet;

	public float Timer;
	public float LimitTimer;

	SpriteRenderer spr;

	public Sprite Weapon;
	Sprite actWeapon;

	// Use this for initialization
	void Start () {
		spr = GetComponent<SpriteRenderer> ();
		actualBullet = Bullet;
		actWeapon = Weapon;
		Direction = -90;
	}
	
	// Update is called once per frame
	void Update () {

		float leftxAxis = Input.GetAxis ("LeftJoystick_X");
		float leftyAxis = Input.GetAxis ("LeftJoystick_Y");
		float R2 = Input.GetAxis ("R2");

		Vector3 movement = transform.TransformDirection (leftxAxis, (-leftyAxis), 0);

		transform.localPosition = new Vector3 (3.8f, 0.2f, 0.0f);

		if (leftxAxis != 0 && leftyAxis != 0) {
			transform.localPosition = movement * 4;
		}

		Timer -= Time.deltaTime;

		spr.sprite = Weapon;

		if (Input.GetButton("L1")){
			Weapon = actWeapon;
			Bullet = actualBullet;
			Timer = 0.2f;
			LimitTimer = 0.2f;
			Ammo = 1000;
		}

		//Arma a la Izquierda
		if(leftxAxis >= 1) {
			//transform.localPosition = new Vector3 (3.8f, 0.2f, 0.0f);
			Direction = -90;
		}

		//Arma a la derecha
		if(leftxAxis <= -1 ) {
			//transform.localPosition =  new Vector3 (-3.8f, -0.2f, -0.0f);
			Direction = 90;
		}

		//Arma hacia arriba
		if (leftyAxis <= -1) {
			//transform.localPosition = new Vector3 (0.2f, 3.7f, 0.0f);
			Direction = 0;
		}

		//Arma hacia abajo
		if (leftyAxis >= 1) {
			//transform.localPosition = new Vector3 (0.2f, -3.0f, 0.0f);
			Direction = 180;
		}

		if  (Input.GetKey (KeyCode.U)) {
			//transform.localPosition = new Vector3 (3.59f, 2.54f, 0.0f);
			Direction = -45;
		}

		if (Input.GetKey (KeyCode.Y)) {
			//transform.localPosition = new Vector3 (-3.59f, 2.54f, 0.0f);
			Direction = 45;
		}
			
		//Disparar el arma

		if (R2 >= 1) {
			if (Timer <= 0 && Ammo >=1) {
				Instantiate (Bullet, transform.position, Quaternion.Euler (0, 0, Direction));
				Timer = LimitTimer;
				Ammo -= 1;
			}
		}
			
		//Arriba
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.localPosition = new Vector3 (0.2f, 3.7f, 0.0f);
		}

		//Abajo
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.localPosition = new Vector3 (0.2f, -3.0f, 0.0f);
		
		}
			
	}
		
}
