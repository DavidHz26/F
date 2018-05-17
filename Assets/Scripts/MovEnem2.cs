using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnem2 : MonoBehaviour 
{
	float velocidad = 5;
	float tiempo = 0;
	float volando = 0;
	float Timer = 0;
	float vida = 3;
	bool vivo = true;
	public GameObject bala;
	GameObject balaActual;
	SpriteRenderer spr;
	public Animator anim;
	
	void Start()
	{
		spr = GetComponent<SpriteRenderer>();
		balaActual = bala;
	}
	
	
	void Update () 
	{
		if(vivo == true)
		{
			tiempo += Time.deltaTime;
			Timer += Time.deltaTime;
			volando += Time.deltaTime;
				
			//Movimiento
			if(tiempo < 3)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
				transform.localRotation = Quaternion.Euler(0, 0, 0);
				
			}
			if(tiempo > 3 && tiempo < 6)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, GetComponent<Rigidbody2D>().velocity.y);
				transform.localRotation = Quaternion.Euler(0, 180, 0);
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
		}
		
		if (Input.GetKeyDown("space"))
		{
			vida-=1;
		}
		//Vida y muerte del murcielago
		if(vida <= 0)
		{	
			vivo = false;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;
			anim.SetBool("muerte", true);
			Destroy(gameObject, 1.0f);
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
