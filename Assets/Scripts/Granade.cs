using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour {

	Rigidbody2D rigi;
	public float gSpeed;

	SpriteRenderer spr;

	public Sprite sGranade;
	public Sprite sBoom;
	
	public GameObject launcher;
	public int dir = 0;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D> ();
		spr = GetComponent<SpriteRenderer> ();
		
		launcher.GetComponent<GranadeController> ().right = dir;
		
		if(dir == 0){
			rigi.AddForce(new Vector2(1.0f, 1.0f) * gSpeed);
		}
		
		if(dir == 1){
			rigi.AddForce(new Vector2(-1.0f, 1.0f) * gSpeed);
		}
	}
	
	void OnCollisionEnter2D(Collision2D _col) {
		if (_col.gameObject.CompareTag ("Suelo")) {
			spr.sprite = sBoom;
			Destroy (gameObject, 0.2f);
		} else {
			spr.sprite = sGranade;
		}
	}
}
