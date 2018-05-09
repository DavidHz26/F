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
	public Sprite Default;
	public Sprite movD;
	public Sprite dashD;
	Rigidbody2D Rigi;
	SpriteRenderer spr;
	
	void Start()
	{
		Rigi = GetComponent<Rigidbody2D>();
		spr = GetComponent<SpriteRenderer> ();
	}
	
	void Update ()
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
			spr.sprite = dashD;
		}
		if(dash > 3.5)
		{
			velocidad = 3 * cambio;
			spr.sprite = movD;
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
		
		//Vida y muerte del vampiro
		if(vida <= 0)
		{
			Destroy(gameObject);
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
			vida-=3;
		}
	}
}
