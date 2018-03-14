using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnem1 : MonoBehaviour
{
	float velocidad = 3;
	float tiempo = 0;
	float dash = 0;
	
	void Update () 
	{
		tiempo += Time.deltaTime;
		dash += Time.deltaTime;
		
		if(tiempo < 3)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
		}
		if(tiempo > 3 && tiempo < 6)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, GetComponent<Rigidbody2D>().velocity.y);
		}
		if(tiempo > 6)
		{
			tiempo = 0;
		}
		
		if(dash > 4)
		{
			velocidad = 8;
		}
		if(dash > 6)
		{
			velocidad = 3;
			dash = 0;
		}
	}
}
