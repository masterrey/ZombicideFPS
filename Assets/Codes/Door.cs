using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public GameObject door;
	float rotation=-90;
	public AudioSource squeak;
	public AudioClip open, close;
	
	IEnumerator Opening(){
		squeak.PlayOneShot (open);
		squeak.Play ();
		
		while(rotation < 0) {
			rotation += Time.deltaTime*50;
			door.transform.localRotation = Quaternion.Euler (0, rotation, 0);
			yield return new WaitForEndOfFrame ();
		}
		//openevent = Closing;
	}
	IEnumerator Closing(){
		
		while(rotation > -90) {
			rotation -= Time.deltaTime*50;
			door.transform.localRotation = Quaternion.Euler (0, rotation, 0);
			yield return new WaitForEndOfFrame ();
		}
		squeak.PlayOneShot (close);
	}
	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
            ActionPoints action = col.GetComponent<ActionPoints>();
            action.openevent = Opening;
			
		}
	}
	void OnTriggerExit(Collider col){
		
	}
}
