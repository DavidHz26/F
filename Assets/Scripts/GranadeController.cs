using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeController : MonoBehaviour {
	
	
	public GameObject pGranade;
	private float Direction;

	public float Timer;
	public float LimitTimer;

	public int Ammo;

	SpriteRenderer spr;
	public Sprite nGranade;

	// Use this for initialization
	void Start () {
		spr = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {

		Timer += Time.deltaTime;

		float xAxis = Input.GetAxis ("Horizontal");
		float L2 = Input.GetAxis ("L2");
		float R1 = Input.GetAxis ("R1");
	
		//Vector3 movement = transform.TransformDirection (xAxis, 0, 0);

		if (xAxis >= 1) {
			transform.localPosition = new Vector3 (2.07f, 2.39f, 0.0f);
			Direction = -45;
		}

		else if (xAxis <= -1) {
			transform.localPosition = new Vector3 (-2.07f, 2.39f, 0.0f);
			Direction = 45;
		}
		
		if(L2 > 1){
			L2 = 1;	
		}

		if (L2 == 1 && Timer <= LimitTimer && Ammo >= 1) {
			Instantiate (pGranade, transform.position, Quaternion.Euler (0, 0, Direction));
			Ammo -= 1;
		}

		if(Input.GetButton("R1")){
			print ("R1");
			spr.sprite = nGranade;
			Timer = 1;
			LimitTimer = 1;
			Ammo = 10;
		}


		if (Timer > LimitTimer) {
			Timer = 0.0f;
		}
	}
}
