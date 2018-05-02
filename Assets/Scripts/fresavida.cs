using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fresavida : MonoBehaviour 
{
	
	void OnCollisionEnter2D (Collision2D _col)
	{
		if(_col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
