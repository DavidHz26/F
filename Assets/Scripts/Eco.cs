using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eco : MonoBehaviour 
{
	float Speed = 0.3f;
	
	void Update () 
	{
		transform.position += transform.up * Speed;
		Destroy (gameObject, 1.0f);
	}
}
