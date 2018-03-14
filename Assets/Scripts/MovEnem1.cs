using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnem1 : MonoBehaviour
{
	float velocidad = 3;
	float dash = 0;
	Rigidbody2D Rigi;
	public bool cont = false;
	
	void Start()
	{
		Rigi = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
	{
		dash += Time.deltaTime;
		
		if(cont == false)
		{
			Rigi.velocity= new Vector2(-velocidad, Rigi.velocity.y);
		}
		else
		{
			Rigi.velocity= new Vector2(velocidad, Rigi.velocity.y);
		}
		
		if(dash > 4)
		{
			velocidad = 18;
		}
		if(dash > 4.5)
		{
			velocidad = 3;
			dash = 0;
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "pader")
		{
			if(cont == false)
			{
				cont = true;
			}
			else
			{
				cont = false;
			}
		}
	}
}
