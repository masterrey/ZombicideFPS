using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPoints : MonoBehaviour {
    public int actions = 3;
    public int actionpassed = 0;
    Vector3 lasttilingpos=Vector3.zero;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tiling"))
        {
            if ((lasttilingpos - other.transform.position).magnitude > 1)
            {
                actionpassed++;
                if(actionpassed>= actions)
                {
                    actionpassed = 0;
                    ActionControl.instance.SetEvent(other.transform.position);
                }
            }
            lasttilingpos = other.transform.position;
        }
    }
}
