using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patron_subjefe : MonoBehaviour 
{
	bool choque = true;
	bool limit = true;
	bool vivo = true;
	public bool fase_juego = true;
	static public bool ataque = false;
	float timer_eco = 0;
	float timer_ataque = 0;
	float vel_mov = 5;
	float vida = 150;
	public float subebaja = 4;
	public float tiempo_juego = 0;
	int quat = 90;
	public int contar = 0;
	public GameObject eco;
	GameObject localizador;
	public GameObject bala;
	GameObject balaActual;
	
	void Start () 
	{
		ataque = false;
		localizador = eco;
		balaActual = bala;
	}
	
	void Update () 
	{
		if(vivo == true)
		{
		//Movimiento comun
		if(contar < 3)
		{
			tiempo_juego = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2(-vel_mov, 0);
		}
		if(contar >= 3)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, -subebaja);
			fase_juego = false;
		}
		
		//Ataque
		if(fase_juego == true)
		{
			if(ataque == true)
			{
				timer_ataque += Time.deltaTime;
				
				if(timer_ataque > 0.5)
				{
					Instantiate (bala, transform.position, Quaternion.Euler (0, 0, 180));
					timer_ataque = 0;
				}
			}
		}
		
		//Ecolocalizacion
		if(fase_juego == false)
		{
			tiempo_juego += Time.deltaTime;
			
			if(tiempo_juego <= 0.2f)
			{
				ataque = false;
			}
			if(tiempo_juego <= 6)
			{
				timer_eco += Time.deltaTime;
			}
			if(tiempo_juego > 6)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, subebaja);
			}
			if(tiempo_juego >= 7.5)
			{
				contar = 0;
				fase_juego = true;
			}
			
			if(timer_eco > 1)
			{
				Instantiate (eco, transform.position, Quaternion.Euler (0, 0, quat));
				timer_eco = 0;
			}
		}
		
		//Cambio de posicion
		if(choque == true)
		{
			vel_mov = 5;
			transform.localRotation = Quaternion.Euler(0, 0, 0);
			quat = 90;
			
		}
		else
		{
			vel_mov = -5;
			transform.localRotation = Quaternion.Euler(0, 180, 0);
			quat = -90;
		}
		}
		
		if (Input.GetKeyDown("space"))
		{
			vida-=50;
		}
		//Vida y muerte del subjefe
		if(vida <= 0)
		{
			vivo = false;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
			Destroy(gameObject, 3.0f);
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(fase_juego == true)
		{
			if(col.gameObject.tag == "pader")
			{
				choque = !choque;
				contar++;
			}
		}
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
