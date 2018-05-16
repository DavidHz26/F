using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float velWalk;
	public float actualWalk;

	public float Jump;

	public bool ground;
	public bool idle;
	
	public float vida = 3;

	SpriteRenderer spr;

	public Sprite Default;
	public Sprite Right;
	public Sprite Up;
	public Sprite Down;
	public Sprite sJump;
	
	public GameObject actSub;
	public GameObject actJef;
	
	//Animator anim;

	void Start () 
	{
		spr = GetComponent<SpriteRenderer> ();
		//anim = GetComponent<Animator> ();
	
		actualWalk = velWalk;
	}

	void Update () 
	{
		idle = true;
		
		//Movimiento
		
		float xAxis = Input.GetAxis ("Horizontal");
		
		Vector3 movement = transform.TransformDirection (xAxis, 0, 0);

		float leftxAxis = Input.GetAxis ("LeftJoystick_X");
		
		transform.Translate (movement * velWalk);
		

		///ANIMACIONES!!!!

		//Movimiento Derecha
		if (xAxis >= 1) {
			idle = false;
			spr.sprite = Right;
			spr.flipX = false;
			
			//anim.SetBool("walk", true);
		}

		//Movimiento Izquierda
		else if (xAxis <= -1) {
			idle = false;
			spr.sprite = Right;
			spr.flipX = true;
			
			//anim.SetBool("walk", true);
		}

		//Movimiento Derecha con Salto
		if (xAxis >= 1 && ground == false) {
			idle = false;
			
			//anim.SetBool("jump", true);
		}

		//Movimiento Izquierda con Salto
		if (xAxis <= -1 && ground == false) {
			idle = false;
			
			//anim.SetBool("jump", true);
		}

		//------------------------------------------------------------------
		
	
		
		//Saltar
		if (Input.GetButton ("A") && ground == true) {
			idle = false;
			ground = false;
			transform.Translate(Vector3.up * Jump);
			spr.sprite = sJump;
			
			//anim.SetBool("jump", true);
			
		}
		else {
			if(ground==true &&  idle == true){
				spr.sprite = Default;
				
				//anim.SetBool("walk", false);
			}
		}
		
		//Morir
		if(vida <= 0)
		{
			//anim.SetBool("death", true);
			SceneManager.LoadScene("GameOver");
	
			//gameObject.SetActive(false);
			//Time.timeScale = 0.0f;
			
		}
	}

	void OnCollisionEnter2D (Collision2D _col)
	{
		//Controlador del salto
		if(_col.gameObject.CompareTag("Suelo")){

			ground = true;

			if (spr.sprite == sJump) {
				spr.sprite = Default;
			} 
		}
		
		//Controlador de vida
		if(_col.gameObject.tag == "enemigote" || _col.gameObject.tag == "balin" || _col.gameObject.tag == "balon")
		{
			//anim.SetBool("damage", true);
			vida--;
		}
		
		if(_col.gameObject.tag == "vida+")
		{
			if(vida < 3)
			{
				vida++;
			}
		}
		
		if(_col.gameObject.tag == "vida++")
		{
			if(vida < 3)
			{
				vida = 3;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D otro)
	{
		if(otro.gameObject.CompareTag("activa1"))
		{
			actSub.GetComponent<patron_subjefe>().enabled = true;
		}
		
		if(otro.gameObject.CompareTag("activa2"))
		{
			actJef.GetComponent<patron_jefe>().enabled = true;
		}
	}
}
