using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    public Text highScore;
    public Text totalCoins;
	// Use this for initialization
	void Start () {
        highScore.text = "Highscore: " + (int)PlayerPrefs.GetFloat("Highscore");
        totalCoins.text = "Total coins: " + PlayerPrefs.GetInt("totalCoins");
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.name == "GoldCounter")
        {
            if(MoveHero.coins != 0)
            {
                GetComponent<Text>().text = "" + MoveHero.coins / 8;
            }
            else
            {
                GetComponent<Text>().text = "" + MoveHero_2.coins;
            }
        }
        if(gameObject.name == "DistanceCounter")
        {
            if(MoveHero.distanceCounter != 0)
            {
                GetComponent<Text>().text = "Distance: " + MoveHero.distanceCounter;
            }
        }
	}
}
