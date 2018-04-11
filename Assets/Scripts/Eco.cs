using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eco : MonoBehaviour 
{
	float Speed = 0.3f;
	float colcont = 0;
	
	static public bool fase_ataque = false;
	
	void Update () 
	{
		colcont += Time.deltaTime;
		
		if(colcont > 0.1)
		{
			gameObject.GetComponent<CircleCollider2D>().enabled = true;
		}
		
		transform.position += transform.up * Speed;
		Destroy (gameObject, 1.0f);
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "player")
		{
			fase_ataque = true;
		}
	}
}
