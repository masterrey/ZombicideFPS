using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPoints : MonoBehaviour {
    public int actions = 3;
    public int actionpassed = 0;
    Vector3 lasttilingpos=Vector3.zero;
    public delegate IEnumerator Openevent();
    public  Openevent openevent;

  

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            if (openevent != null)
            {
                StartCoroutine(openevent());
                openevent = null;
                ActionCount();
            }
        }
    }

    void ActionCount()
    {
        actionpassed++;
        if (actionpassed >= actions)
        {
            actionpassed = 0;
            ActionControl.instance.SetEvent(transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tiling"))
        {
            if ((lasttilingpos - other.transform.position).magnitude > 1)
            {
                ActionCount();
            }
            lasttilingpos = other.transform.position;
        }
    }
}
