using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patron_subjefe : MonoBehaviour 
{
	bool fase_juego = true;
	bool ataque = false;
	public float tiempo_mov = 0;
	float vel_mov = 5;
	public float tiempo_juego1 = 0;
	public float tiempo_juego2 = 0;
	float timer_eco = 0;
	public GameObject eco;
	GameObject localizador;
	public GameObject bala;
	GameObject balaActual;
	
	void Start () 
	{
		localizador = eco;
	}
	
	void Update () 
	{
		tiempo_juego1 += Time.deltaTime;
		//tiempo_juego += Time.deltaTime;
		
		if(tiempo_juego1 > 13)
		{
			fase_juego = false;
		}
		if(tiempo_juego1 > 25)
		{
			fase_juego = true;
			tiempo_juego1 = 0;
		}
		
		if(fase_juego == true)
		{
			
			fase1();
		}
		else
		{
			fase2();
		}
	}
	
	//Movimiento comun
	void fase1()
	{		
		tiempo_mov += Time.deltaTime;
		
		if(tiempo_mov < 3)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-vel_mov, 0);
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		if(tiempo_mov > 3)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(vel_mov, 0);
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
		if(tiempo_mov > 6)
		{
			tiempo_mov = 0;
		}
		
		if(tiempo_juego1 > 10)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, -vel_mov);
		}
		
		/*if(tiempo_juego1 == 13)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		}*/
		
		if(ataque == true)
		{
			if(timer_eco > 1)
			{
				Instantiate (bala, transform.position, Quaternion.Euler (0, 0, 180));
				timer_eco = 0;
			}
		}
	}
	
	//Ecolocalizacion
	void fase2()
	{
		timer_eco += Time.deltaTime;
		
		if(timer_eco > 1)
		{
			Instantiate (eco, transform.position, Quaternion.Euler (0, 0, -90));
			timer_eco = 0;
		}
		
		/*if(tiempo_juego1 > 23);
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, vel_mov);
		}*/
		
		/*if(tiempo_juego2 > 12);
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			ataque = !ataque;
			fase_juego = 1;
		}*/
	}
}
