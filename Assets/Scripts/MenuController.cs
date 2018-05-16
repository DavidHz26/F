using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	//Jugar
	public void Play(){
		SceneManager.LoadScene("Level");
	}
	
	//Menu
	public void Menu(){
		SceneManager.LoadScene("Menu");
	}
	
	//Creditos
	public void Credits(){
		SceneManager.LoadScene("Creditos");
	}
	
	//Salir
	public void Exit(){
		Application.Quit();
	}
}
