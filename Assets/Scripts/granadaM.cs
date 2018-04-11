using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granadaM : MonoBehaviour 
{
	float Speed = 0.2f;
	float colcont = 0;
	
	void Update () 
	{
		colcont += Time.deltaTime;
		
		if(colcont > 0.2)
		{
			gameObject.GetComponent<CircleCollider2D>().enabled = true;
		}
		
		transform.position += transform.up * Speed;
		Destroy (gameObject, 1.0f);
	}
}
