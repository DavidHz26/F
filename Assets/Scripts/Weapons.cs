using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {
	
	public int numWeapon = 1;

	public int Direction;
	public float Speed;
	public int Ammo;

	public GameObject Bullet;
	public GameObject Bullet1;
	public GameObject Bullet2;
	public GameObject Bullet3;

	public float Timer;
	public float LimitTimer;

	SpriteRenderer spr;

	public Sprite Weapon1;
	public Sprite Weapon2;
	public Sprite Weapon3;

	// Use this for initialization
	void Start () 
	{
		spr = GetComponent<SpriteRenderer> ();
		Direction = -90;
	}
	
	// Update is called once per frame
	void Update () {
		
		

		float leftxAxis = Input.GetAxis ("LeftJoystick_X");
		float leftyAxis = Input.GetAxis ("LeftJoystick_Y");
		float R2 = Input.GetAxis ("R2");
		print(leftxAxis + "  -  " +leftyAxis );

		Vector3 movement = transform.TransformDirection (leftxAxis, (-leftyAxis), 0);

		transform.localPosition = new Vector3 (3.8f, 0.2f, 0.0f);

		if (leftxAxis != 0 && leftyAxis != 0) {
			transform.localPosition = movement * 4;
		}

		Timer -= Time.deltaTime;
		
		if(numWeapon == 1)
		{
			spr.sprite = Weapon1;
			Bullet = Bullet1;
			Timer = 0.2f;
			LimitTimer = 0.2f;
			Ammo = 1000;
			numWeapon = 0;
		}
		else if(numWeapon == 2)
		{
			spr.sprite = Weapon2;
			Bullet = Bullet2;
			Timer = 0.8f;
			LimitTimer = 0.8f;
			Ammo = 7;
			numWeapon = 0;
		}
		else if(numWeapon == 3)
		{
			spr.sprite = Weapon3;
			Bullet = Bullet3;
			Timer = 0.1f;
			LimitTimer = 0.1f;
			Ammo = 60;
			numWeapon = 0;
		}

		if (Input.GetButton("L1"))
		{
			numWeapon = 1;
		}
		
		if(leftxAxis == 0 && leftyAxis == 0){
			Direction = -90;
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

		if  (leftxAxis >= 0.8f && leftyAxis <= -0.4f) {
			//transform.localPosition = new Vector3 (3.59f, 2.54f, 0.0f);
			Direction = -45;
		}

		if  (leftxAxis <= -0.8f && leftyAxis <= -0.4f) {
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
			
	}
		
}
