using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnem1 : MonoBehaviour
{
	float velocidad = 3;
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
		
		if(cont == false)
		{
			Rigi.velocity= new Vector2(-velocidad, 0);
			transform.localRotation = Quaternion.Euler(0, 0, 0);
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
			Rigi.velocity= new Vector2(velocidad, 0);
			transform.localRotation = Quaternion.Euler(0, 180, 0);
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
		if(col.gameObject.tag == "pader")
		{
			cont = !cont;
		}
	}
}
