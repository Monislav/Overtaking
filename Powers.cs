using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.tag == "Bonus")
        {
            transform.Rotate(0, 0, 3);
        }
        if (gameObject.name == "CoinMeter")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, MoveHero.zMove);
            if (MoveHero.stopMove == "yes")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
