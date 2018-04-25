using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eco : MonoBehaviour 
{
	float Speed = 0.3f;
	float colcont = 0;
	
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
		if(col.gameObject.tag == "Player")
		{
			patron_subjefe.ataque = true;
		}
		
		if(col.gameObject.tag == "pader")
		{
			Destroy(gameObject);
		}
		
		if(col.gameObject.tag == "Suelo")
		{
			Destroy(gameObject);
		}
	}
}
