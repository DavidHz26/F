using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausar : MonoBehaviour 
{
	public GameObject menup;
	public GameObject player;
	public GameObject camara2;
	
	void Start () 
	{
		Time.timeScale = 1;
		camara2.SetActive(false);
	}
	
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			menup.SetActive(true);
			camara2.SetActive(true);
			Time.timeScale = 0;
			player.SetActive(false);
		}
	}
	
	public void Continuar()
	{
		menup.SetActive(false);
		camara2.SetActive(false);
		player.SetActive(true);
		Time.timeScale = 1;
	}
}
