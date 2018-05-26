using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZombieIA : MonoBehaviour
{
    public GameObject[] waypoints;
    public AICharacterControl aichar;
    private int actionpassed;
    private Vector3 lasttilingpos;
    public int actions=1;

    // Use this for initialization
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Tiling");
        ActionControl.instance.eventcallback += EventReceiver;
        aichar = GetComponent<AICharacterControl>();
    }
    void EventReceiver(Vector3 pos)
    {

        aichar.SetTarget(pos);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tiling"))
        {
            if ((lasttilingpos - other.transform.position).magnitude > 1)
            {
                actionpassed++;
                if (actionpassed == actions)
                {
                    actionpassed = 0;
                    aichar.Stop();
                    //aichar.SetTarget(transform.position);
                }
                lasttilingpos = other.transform.position;
            }
        }
    }
}
