using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnem1 : MonoBehaviour
{
	float velocidad = 3;
	float dash = 0;
	Rigidbody2D Rigi;
	public bool cont = false;
	float vida = 10;
	SpriteRenderer spr;
	public Sprite Default;
	public Sprite movD;
	public Sprite movI;
	public Sprite dashD;
	public Sprite dashI;
	
	void Start()
	{
		Rigi = GetComponent<Rigidbody2D>();
		spr = GetComponent<SpriteRenderer> ();
	}
	
	void Update () 
	{
		dash += Time.deltaTime;
		
		if(cont == false)
		{
			Rigi.velocity= new Vector2(-velocidad, Rigi.velocity.y);
			spr.sprite = movD;
			if(dash > 4)
			{
				velocidad = 18;
				spr.sprite = dashD;
			}
			if(dash > 4.5)
			{
				velocidad = 3;
				spr.sprite = movD;
				dash = 0;
			}
		}
		else
		{
			Rigi.velocity= new Vector2(velocidad, Rigi.velocity.y);
			spr.sprite = movI;
			if(dash > 4)
			{
				velocidad = 18;
				spr.sprite = dashI;
			}
			if(dash > 4.5)
			{
				velocidad = 3;
				spr.sprite = movI;
				dash = 0;
			}
		}
		
		if(Input.GetKeyDown(KeyCode.V))
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
		if(col.gameObject.tag == "pader")
		{
			cont = !cont;
		}
	}
}
