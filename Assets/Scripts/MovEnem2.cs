using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnem2 : MonoBehaviour 
{
	float velocidad = 5;
	float tiempo = 0;
	float volando = 0;
	float Timer = 0;
	float vida = 5;
	public GameObject bala;
	GameObject balaActual;
	SpriteRenderer spr;
	public Sprite Default;
	public Sprite Vuelo;
	
	void Start()
	{
		spr = GetComponent<SpriteRenderer>();
		balaActual = bala;
	}
	
	
	void Update () 
	{
		tiempo += Time.deltaTime;
		Timer += Time.deltaTime;
		volando += Time.deltaTime;
		
		//Animacion
		if(volando < 0.5)
		{
			spr.sprite = Default;
		}
		if(volando > 0.5 && volando < 1)
		{
			spr.sprite = Vuelo;
		}
		if(volando > 1)
		{
			volando = 0;
		}
		
		//Movimiento
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
		
		//Proyectil enemigo
		if(Timer > 1.5)
		{
			Instantiate (bala, transform.position, Quaternion.Euler (0, 0, 180));
			Timer = 0;
		}
		
		//Vida y muerte del murcielago
		if(Input.GetKeyDown(KeyCode.M))
		{
			vida--;
		}
		if(vida <= 0)
		{
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Banana")
		{
			vida-=1;
		}
		if(col.gameObject.tag == "Uvas")
		{
			vida-=3;
		}
	}
}
