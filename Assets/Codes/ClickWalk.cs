using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ClickWalk : MonoBehaviour {
    public AICharacterControl aichar;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000))
        {
            Debug.DrawLine(transform.position, hit.point);
            if (Input.GetButtonDown("Fire1")) { 
        
           
                aichar.SetTarget(hit.point);
            }
        }
            
    
    }
}
