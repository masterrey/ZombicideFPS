using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoCam : MonoBehaviour {
    public GameObject tgt;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (tgt)
        {
            transform.position = Vector3.Lerp(transform.position, tgt.transform.position + offset, Time.smoothDeltaTime) ;
            transform.LookAt(tgt.transform);
        }
	}
}
