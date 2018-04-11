using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGranade : MonoBehaviour {

	public GameObject cGranade;
	public GameObject newGranade;

	//public Sprite Granade2;

	public float newTimer;
	public float newLimitTimer;

	public int _Ammo;

	void OnTriggerEnter2D (Collider2D _col){
		if(_col.gameObject.CompareTag("Player")){

			cGranade.GetComponent<GranadeController> ().Ammo = _Ammo;

			if (_Ammo >= 1) {
				cGranade.GetComponent<GranadeController> ().Timer = newTimer;
				cGranade.GetComponent<GranadeController> ().LimitTimer = newLimitTimer;
				cGranade.GetComponent<GranadeController> ().pGranade = newGranade;

				Destroy (gameObject);
				_Ammo -= 1;
			} 
		}

	}
}
