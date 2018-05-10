using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour {

	Rigidbody2D rigi;
	public float gSpeed;

	SpriteRenderer spr;

	public Sprite sGranade;
	public Sprite sBoom;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D> ();
		spr = GetComponent<SpriteRenderer> ();

		
		rigi.AddForce(new Vector2(1.0f, 1.0f) * gSpeed);
	}

	// Update is called once per frame
	void Update () {
		

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
