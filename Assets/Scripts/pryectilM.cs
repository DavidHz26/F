using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pryectilM : MonoBehaviour 
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
		if(col.gameObject.tag == "pader" || col.gameObject.tag == "Suelo" || col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
