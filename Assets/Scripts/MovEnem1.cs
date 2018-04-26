﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnem1 : MonoBehaviour
{
	float velocidad = -3;
	float cambio = -1;
	int pos;
	float dash = 0;
	bool cont = false;
	public Sprite Default;
	public Sprite movD;
	public Sprite dashD;
	Rigidbody2D Rigi;
	SpriteRenderer spr;
	float vida = 10;
	
	void Start()
	{
		Rigi = GetComponent<Rigidbody2D>();
		spr = GetComponent<SpriteRenderer> ();
	}
	
	void Update ()
	{
		dash += Time.deltaTime;
		
		Rigi.velocity= new Vector2(velocidad, 0);
		if(dash > 3)
		{
			velocidad = 18 * cambio;
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
		
		/*if(Input.GetKeyDown(KeyCode.V))
		{
			vida--;
		}
		
		if(vida <= 0)
		{
			Destroy(gameObject);
		}*/
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
	}
}
