using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnem2 : MonoBehaviour {
	
	int Direction = 180;
	float velocidad = 5;
	float tiempo = 0;
	
	public GameObject bala;
	GameObject balaActual;
	
	float Timer = 0;
	
	SpriteRenderer spr;
	
	void Start()
	{
		spr = GetComponent<SpriteRenderer>();
		balaActual = bala;
	}
	
	
	void Update () 
	{
		tiempo += Time.deltaTime;
		Timer += Time.deltaTime;
		
		if(tiempo < 3)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
		}
		if(tiempo > 3 && tiempo < 6)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, GetComponent<Rigidbody2D>().velocity.y);
		}
		if(tiempo > 6)
		{
			tiempo = 0;
		}
		
		if(Timer > 1.5)
		{
			Instantiate (bala, transform.position, Quaternion.Euler (0, 0, Direction));
			Timer = 0;
		}
	}
}
