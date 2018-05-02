using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWeapon : MonoBehaviour {

	public GameObject cWeapon;
	public int _numWeapon;

	void OnTriggerEnter2D (Collider2D _col)
	{
		if(_col.gameObject.CompareTag("Player"))
		{
			cWeapon.GetComponent<Weapons> ().numWeapon = _numWeapon;
			Destroy (gameObject); 
		}

	}
}
