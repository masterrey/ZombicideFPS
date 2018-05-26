using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public GameObject prefab;
	// Use this for initialization
	void Start () {
        ActionControl.instance.eventcallback += EventReceiver;

    }
    void EventReceiver(Vector3 pos)
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
