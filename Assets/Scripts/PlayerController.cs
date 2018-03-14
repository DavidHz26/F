using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float velWalk;
	public float VelRun;
	public float Jump;

	public bool ground;
	public bool running;
	public bool idle;

	SpriteRenderer spr;

	public Sprite Default;
	public Sprite Right;
	public Sprite Up;
	public Sprite Down;
	public Sprite sJump;
	public Sprite Run;

	// Use this for initialization
	void Start () {
		spr = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (idle == true && ground == true || idle == true && ground == false) {
			spr.sprite = sJump;
		} else {
			spr.sprite = Default;
		}

		//Movimiento Derecha
		if (Input.GetKey (KeyCode.D)) {
			idle = false;
			spr.sprite = Right;
			spr.flipX = false;
			transform.Translate (velWalk, 0.0f, 0.0f);
		}

		//Movimiento Izquierda
		else if (Input.GetKey (KeyCode.A)) {
			idle = false;
			spr.sprite = Right;
			spr.flipX = true;
			transform.Translate (-velWalk, 0.0f, 0.0f);
		} else {
			idle = true;
		}

		//Movimiento Derecha con Salto
		if (Input.GetKey (KeyCode.D) && ground == false) {
			spr.sprite = sJump;
			idle = false;
		}

		//Movimiento Izquierda con Salto
		if (Input.GetKey (KeyCode.A) && ground == false) {
			spr.sprite = sJump;
			idle = false;
		}
			
		//Correr Derecha
		if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.LeftShift)) {
			idle = false;
			running = true;
			transform.Translate (VelRun, 0.0f, 0.0f);
		} 

		//Correr Izquierda
		else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.LeftShift)) {
			idle = false;
			running = true;
			transform.Translate (-VelRun, 0.0f, 0.0f);
		} else {
			running = false;
		}

		//Saltar
		if (Input.GetKey (KeyCode.W) && ground == true) {
			transform.Translate (0.0f, Jump, 0.0f);
			idle = false;
			ground = false;
			spr.sprite = sJump;
		}
			
		//Mover la direccion de disparo
		if (Input.GetKey (KeyCode.UpArrow) && ground == true) {
			idle = false;
			spr.sprite = Up;
		} else if (Input.GetKey (KeyCode.UpArrow) && ground == false) {
			idle = false;
			spr.sprite = sJump;
		} else if (Input.GetKey (KeyCode.DownArrow) && ground == true) {
			idle = false;
			spr.sprite = Down;
		} else if (Input.GetKey (KeyCode.DownArrow) && ground == false) {
			spr.sprite = sJump;
			idle = false;
		}

		else {
			if(ground==true && running == false && idle == true){
				spr.sprite = Default;
			}
			else if(ground==true && running == true && idle==false){
				spr.sprite = Run;
			}
		}

	
		
	}

	void OnCollisionEnter2D (Collision2D _col){

		//Controlador del salto
		if(_col.gameObject.CompareTag("Suelo")){
			
			ground = true;

			if (spr.sprite == sJump && running == false) {
				spr.sprite = Default;
			} 
			else if (spr.sprite == sJump && running == true) {
				spr.sprite = Run;
			}

		}
	}
}
