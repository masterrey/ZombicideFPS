using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
	public float Velocidade = 1;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, Velocidade * 180 * Time.deltaTime, 0);
	}
}
