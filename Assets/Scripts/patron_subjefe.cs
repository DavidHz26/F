using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patron_subjefe : MonoBehaviour 
{
	float tiempo_mov = 0;
	float vel_mov = 5;
	float tiempo_juego = 0;
	float timer_eco = 0;
	int pos_eco = -3;
	bool ecos = false;
	public GameObject bala;
	GameObject balaActual;
	
	void Start () 
	{
		balaActual = bala;
	}
	
	void Update () 
	{
		tiempo_mov += Time.deltaTime;
		tiempo_juego += Time.deltaTime;
		
		if(tiempo_juego <= 14)
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
		if(tiempo_mov < 3)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-vel_mov, GetComponent<Rigidbody2D>().velocity.y);
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		if(tiempo_mov > 3)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(vel_mov, GetComponent<Rigidbody2D>().velocity.y);
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
		if(tiempo_mov > 6)
		{
			tiempo_mov = 0;
		}
	}
	
	//Ecolocalizacion
	void fase2()
	{
		transform.localRotation = Quaternion.Euler(0, 180, 0);
		GetComponent<Rigidbody2D>().velocity = new Vector2(-vel_mov, GetComponent<Rigidbody2D>().velocity.x);
		timer_eco += Time.deltaTime;
		
		if(ecos == false)
		{
			pos_eco = -3;
		}
		
		if(timer_eco > 1.5)
		{
			Instantiate (bala, new Vector3(-3, pos_eco, 0), Quaternion.Euler (0, 0, -90));
			timer_eco = 0.5;
			
		}
	}
}
