using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {
	
	public bool ground;
	public bool idle;
	
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		idle=true;
		
		float xAxis = Input.GetAxis ("Horizontal");
		
		Vector3 movement = transform.TransformDirection (xAxis, 0, 0);
		
		float leftxAxis = Input.GetAxis ("LeftJoystick_X");
		
			//Movimiento Derecha
		if (xAxis >= 1) {
			idle = false;
		
			//transform.localScale = new Vector3(transform.localScale.x * 1, transform.localScale.y, transform.localScale.z);
			anim.SetBool("walk", true);
			
		}
		
		//Movimiento Izquierda
		else if (xAxis <= -1) {
			idle=false;
			
			//transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			anim.SetBool("walk", true);
		}
		
		//Movimiento Derecha con Salto
		if (xAxis >= 1 && ground == false) {
			idle=false;
			anim.SetBool("jump", true);
		}
		
		//Movimiento Izquierda con Salto
		if (xAxis <= -1 && ground == false) {
			idle=false;
			anim.SetBool("jump", true);
		}
		
		//Saltar
		if (Input.GetButton ("A") && ground == true) {	
			idle=false;
			ground=false;
			anim.SetBool("jump", true);
			
		}
		else {
			if(ground==true &&  idle == true){
			
				anim.SetBool("walk", false);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D _col)
	{
		//Controlador del salto
		if(_col.gameObject.CompareTag("Suelo")){
			
			ground = true;
			anim.SetBool("jump", false);
		}
		
		//Controlador de vida
		if(_col.gameObject.tag == "enemigote" || _col.gameObject.tag == "balin" || _col.gameObject.tag == "balon")
		{
			anim.SetBool("damage", true);
		}

	}
	
	void OnTriggerEnter2D (Collider2D _col){
		if(_col.gameObject.CompareTag("balin")){
			anim.SetBool("damage", true);
		}
	}
}