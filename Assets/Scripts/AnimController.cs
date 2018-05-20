using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {
	
	public bool ground;
	public bool idle;
	
	Animator anim;
	
	public bool view = true;
	public bool seguro = false;
	
	float temp = 0;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		
		idle=true;
		
		float xAxis = Input.GetAxis ("Horizontal");
		
		Vector3 movement = transform.TransformDirection (xAxis, 0, 0);
		
		
		
		if(view == true){
			transform.localScale = new Vector3(3.571913f, 3.571913f, 3.571913f);
			
		}
		
		else if(view == false){
			transform.localScale = new Vector3(-3.571913f, 3.571913f, 3.571913f);
		}
		
		float leftxAxis = Input.GetAxis ("LeftJoystick_X");
		
			//Movimiento Derecha
		if (xAxis >= 1) {
			idle = false;
			view = true;
			seguro = false;
			anim.SetBool("walk", true);
			
		}
		
		//Movimiento Izquierda
		else if (xAxis <= -1) {
			idle=false;
			view = false;
			seguro = true;
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
		if(_col.gameObject.CompareTag("enemigote") || _col.gameObject.CompareTag("balin") || _col.gameObject.CompareTag("balon"))
		{
			print("Me hicieron daño!");
			//temp += Time.deltaTime;
			anim.SetBool("damage", true);
			/*if(temp <= 2.0f){
				anim.SetBool("damage", false);
			}*/
		}

	}
}