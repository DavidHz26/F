using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnem2 : MonoBehaviour {

	float velocidad = 5;
	float tiempo = 0;
	
	
	void Update () 
	{
		tiempo += Time.deltaTime;
		
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
	}
}
