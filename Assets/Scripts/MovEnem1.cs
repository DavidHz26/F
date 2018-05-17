using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnem1 : MonoBehaviour
{
	float velocidad = -3;
	float cambio = -1;
	float vida = 5;
	float dash = 0;
	int pos;
	bool cont = false;
	bool vivo = true;
	Rigidbody2D Rigi;
	SpriteRenderer spr;
	
	public Animator anim;
	
	void Start()
	{
		Rigi = GetComponent<Rigidbody2D>();
		spr = GetComponent<SpriteRenderer> ();
	}
	
	void Update ()
	{
		if(vivo == true)
		{
			dash += Time.deltaTime;
			
			Rigi.velocity= new Vector2(velocidad, 0);
			if(dash >2.8)
			{
				velocidad = 0 * cambio;
			}
			if(dash > 3)
			{
				velocidad = 24 * cambio;
			}
			if(dash > 3.5)
			{
				velocidad = 3 * cambio;
				dash = 0;
			}
			
			if(cont == false)
			{
				transform.localRotation = Quaternion.Euler(0, 0, 0);
			}
			else
			{
				transform.localRotation = Quaternion.Euler(0, 180, 0);
			}
		}
		
		if (Input.GetKeyDown("space"))
		{
			vida-=1;
		}
		//Vida y muerte del vampiro
		if(vida <= 0)
		{
			vivo = false;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;
			anim.SetBool("muerte", true);
			Destroy(gameObject, 1.0f);
		}
	}
	
	//Cambio de direccion
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "pader" || col.gameObject.tag == "Player")
		{
			cont = !cont;
			velocidad = velocidad * -1;
			cambio = cambio * -1;
		}
		
		if(col.gameObject.tag == "Banana")
		{
			vida-=1;
		}
		if(col.gameObject.tag == "Uvas")
		{
			vida-=5;
		}
		if(col.gameObject.tag == "Sandia")
		{
			vida-=3;
		}
		
	}
}
