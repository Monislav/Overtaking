using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
        if (MoveHero.stopMove == "yes")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
