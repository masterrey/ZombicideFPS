using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public GameObject door;
	delegate IEnumerator Openevent();
	Openevent openevent;
	float rotation=-90;
	public AudioSource squeak;
	public AudioClip open, close;
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			if (openevent != null)
				StartCoroutine (openevent());
		}
	}
	IEnumerator Opening(){
		squeak.PlayOneShot (open);
		squeak.Play ();
		openevent = null;
		while(rotation < 0) {
			rotation += Time.deltaTime*50;
			door.transform.localRotation = Quaternion.Euler (0, rotation, 0);
			yield return new WaitForEndOfFrame ();
		}
		//openevent = Closing;
	}
	IEnumerator Closing(){
		openevent = null;
		while(rotation > -90) {
			rotation -= Time.deltaTime*50;
			door.transform.localRotation = Quaternion.Euler (0, rotation, 0);
			yield return new WaitForEndOfFrame ();
		}
		//openevent = Opening;
		squeak.PlayOneShot (close);
	}
	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			if (rotation < -30) {
				openevent = Opening;
			} else {
				openevent = Closing;
			}
		}
	}
	void OnTriggerExit(Collider col){
		StopAllCoroutines ();
		StartCoroutine(Closing());
		openevent = null;
	}
}
