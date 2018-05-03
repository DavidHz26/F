using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	//Jugar
	void Play(){
		SceneManager.LoadScene("Demo");
	}
	
	void Credits(){
		SceneManager.LoadScene("Creditos");
	}
	
	void Exit(){
		Application.Quit;
	}
}
