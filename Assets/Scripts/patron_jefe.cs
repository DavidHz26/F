using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patron_jefe : MonoBehaviour 
{
	int coorgran = 45;
	float velocidad = 6;
	float dash = 0;
	float timerD = 0;
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
	
	void Start () 
	{
		Rigi = GetComponent<Rigidbody2D>();
		Fderecha = fuegoD;
		FIzquierda = fuegoI;
		Farriba = fuegoA;
		Mgranad = granadin;
	}
	
	void Update () 
	{
		dash += Time.deltaTime;
		
		if(dash <= 8)
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
		if(dash > 8)
		{
			velocidad = 20;
		}
		if(dash > 12)
		{
			velocidad = 0;
		}
		if(dash > 14)
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
	}
	
	//Cambio de direccion
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "pader" || col.gameObject.tag == "Player")
		{
			coli = !coli;
		}
	}
}
