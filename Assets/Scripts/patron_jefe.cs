using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class patron_jefe : MonoBehaviour 
{
	int coorgran = 45;
	float velocidad;
	float dash = 0;
	float timerD = 0;
	float vida = 50;
	bool coli = false;
	public GameObject fuegoD;
	public GameObject fuegoI;
	public GameObject fuegoA;
	public GameObject granadin;
	GameObject Fderecha;
	GameObject FIzquierda;
	GameObject Farriba;
	GameObject Mgranad;
	Rigidbody2D Rigi;
	
	public GameObject Frutivictoria;
	
	Animator anim;
	
	void Start () 
	{
		anim = GetComponent<Animator> ();
		Rigi = GetComponent<Rigidbody2D>();
		Fderecha = fuegoD;
		FIzquierda = fuegoI;
		Farriba = fuegoA;
		Mgranad = granadin;
	}
	
	void Update () 
	{
		dash += Time.deltaTime;
		
		if(dash <= 7.8) //Movimiento principal
		{
			timerD += Time.deltaTime;
			velocidad = 6;
			if(timerD > 1.5)
			{
				Instantiate (fuegoD, transform.position, Quaternion.Euler (0, 0, 90));
				Instantiate (fuegoI, transform.position, Quaternion.Euler (0, 0, -90));
				Instantiate (fuegoA, transform.position, Quaternion.Euler (0, 0, 0));
				timerD = 0;
			}
			
		}
		if(dash > 7.8)
		{
			velocidad = 0;
		}
		if(dash > 8) //Super velocidad
		{
			velocidad = 24;
		}
		if(dash > 12) //Descanso
		{
			velocidad = 0;
		}
		if(dash > 14) //Movimiento y ataque lento
		{
			velocidad = 2;
			
			timerD += Time.deltaTime;
			if(timerD > 0.8)
			{
				Instantiate (granadin, transform.position, Quaternion.Euler (0, 0, coorgran));
				timerD = 0;
			}
		}
		if(dash > 17)
		{
			dash = 0;
		}
		
		//Cambio de direccion
		if(coli == false)
		{
			Rigi.velocity= new Vector2(-velocidad, 0);
			transform.localRotation = Quaternion.Euler(0, 0, 0);
			coorgran = 45;
		}
		else
		{
			Rigi.velocity= new Vector2(velocidad, 0);
			transform.localRotation = Quaternion.Euler(0, 180, 0);
			coorgran = -45;
		}
		
		//Vida y muerte del subjefe
		if(vida <= 0)
		{
			Frutivictoria.SetActive(true);
			Invoke("CargarMenu", 0.5f);
			Destroy(gameObject);
			
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "pader" || col.gameObject.tag == "Player")
		{
			coli = !coli;
		}
		if(col.gameObject.tag == "Banana")
		{
			vida-=1;
		}
		if(col.gameObject.tag == "Uvas")
		{
			vida-=5;
		}
		if(col.gameObject.tag == "Sandia")
		{
			vida-=3;
		}
	}
	
	void CargarMenu(){
		SceneManager.LoadScene("Menu");
	}
}
