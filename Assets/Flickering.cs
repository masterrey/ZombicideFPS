using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour {
	public Light light;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
		SwitchOn ();
	}
	
	void SwitchOn(){
		light.enabled = true;
		Invoke ("SwitchOff", Random.Range (0.01f, 0.05f));
	}

	void SwitchOff(){
		light.enabled = false;
		Invoke ("SwitchOn", Random.Range (1f,5));
	}
}
