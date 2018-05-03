using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausar : MonoBehaviour 
{
	public GameObject a;
	
	void Start () 
	{
	}
	
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			a.SetActive(true);
			Time.timeScale = 0;
		}
	}
	
	public void Continuar()
	{
		a.SetActive(false);
		Time.timeScale = 1;
	}
}
