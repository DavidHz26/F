using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeController : MonoBehaviour 
{
	public GameObject pGranade;
	private float Direction;

	public float Timer;
	public float LimitTimer;

	public int Ammo;

	SpriteRenderer spr;
	public Sprite nGranade;

	public bool pressL2 = false;
	
	public int right;

	void Start () 
	{
		spr = GetComponent<SpriteRenderer> ();
		right = 0;
	}

	void Update () 
	{
		Timer += Time.deltaTime;

		float xAxis = Input.GetAxis ("Horizontal");
		float L2 = Input.GetAxis ("L2");
		//print (L2);
		
		//Vector3 movement = transform.TransformDirection (xAxis, 0, 0);
		if (xAxis >= 1) {
			transform.localPosition = new Vector3 (3.63f, 4.21f, 0.0f);
			Direction = -45;
			right = 0;
			
		}

		else if (xAxis <= -1) {
			transform.localPosition = new Vector3 (-4.4f, 4.21f, 0.0f);
			Direction = 45;
			right = 1;
		}
		
		if(L2 >= 0.5f && pressL2 == false && Ammo > 0){
			pressL2 = true;
			Instantiate (pGranade, transform.position, Quaternion.Euler (0, 0, Direction));
			Ammo -= 1;
		}


		if(L2 < 0.5f)
		{
			pressL2 = false;
			
		}
			
		if (Timer >= LimitTimer+1) {
			Timer = 0.0f;
		}
	}
}
