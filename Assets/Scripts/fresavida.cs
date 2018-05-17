using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fresavida : MonoBehaviour 
{
	
	SpriteRenderer spt;
	public Sprite FrutaExp;
	
	void Start(){
		spt = GetComponent<SpriteRenderer>();
	}
	
	void OnCollisionEnter2D (Collision2D _col)
	{
		if(_col.gameObject.tag == "Player")
		{
			spt.sprite = FrutaExp; 
			Destroy(gameObject, 0.1f);
		}
	}
}
