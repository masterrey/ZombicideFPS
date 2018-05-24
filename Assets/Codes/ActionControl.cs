using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionControl : MonoBehaviour {
    public static ActionControl instance; //sigleton
    public Vector3 lasteventposition; 
    public delegate void Eventcallback(Vector3 pos);
    public Eventcallback eventcallback;
    // Use this for initialization
    void Start () {
        instance = this;
    }
    public void SetEvent(Vector3 position)
    {
        eventcallback(position);
        lasteventposition =position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
