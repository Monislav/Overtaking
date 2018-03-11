using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveHero : MonoBehaviour {
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public int laneNum = 2;
    public static int zMove = 20;
    public float xMove = 0;
    public string lockMove = "no";
    public static string stopMove = "no";
    public Text goldCount;
    public Text distanceCount;
    public static int coinCounter;
    public static float distanceCounter;
    public int coinBalance;
    public AudioClip impact;
    public static int coins;
    public float distance;

    // Use this for initialization
    void Start ()
    {
        coinBalance = PlayerPrefs.GetInt("totalCoins");
        coinCounter = 0;
        SetText();
    }
	
	// Update is called once per frame
	void Update ()
    {
        goldCount = GameObject.Find("goldCount").GetComponent<Text>();
        distanceCount = GameObject.Find("distanceCount").GetComponent<Text>();
        distanceCounter = (int)transform.position.z + distance;
        GetComponent<Rigidbody>().velocity = new Vector3(xMove, 0, zMove);
        SetText_2();
        if (Input.GetKeyDown(moveLeft) && (laneNum > 1) && (lockMove == "no"))
        {
                xMove = -11.3f;
                laneNum -= 1;
                lockMove = "yes";
                StartCoroutine(stopSlide());
        }
        if (Input.GetKeyDown(moveRight) && (laneNum <= 2) && (lockMove == "no"))
        {
            xMove = 11.3f;
            laneNum += 1;
            lockMove = "yes";
            StartCoroutine(stopSlide());
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            stopMove = "yes";
            Platform.lvlStatus = "Fail";
            if(PlayerPrefs.GetFloat("Highscore") < distanceCounter)
            {
                PlayerPrefs.SetFloat("Highscore", distanceCounter);
            }
            coinBalance += coinCounter;
            PlayerPrefs.SetInt("totalCoins", coinBalance);
            coinCounter = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bonus")
        {
            AudioSource.PlayClipAtPoint(impact, transform.position);
            Destroy(other.gameObject);
            coinCounter++;
            coins++;
            if(coinCounter > 1)
            {
                coinCounter -= 7;
            }
            SetText();
        }
        if (other.gameObject.tag == "BigBonus")
        {
            AudioSource.PlayClipAtPoint(impact, transform.position);
            Destroy(other.gameObject);
            coinCounter += 3;
            coins += 3;
            SetText();
        }
        if (other.gameObject.tag == "BonusLevel")
        {
            distance = distanceCounter;
            gameObject.GetComponent<MoveHero>().enabled = false;
            gameObject.transform.position = new Vector3(2.7f, 0, 5.5f);
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            gameObject.GetComponent<BonusMove>().enabled = true;
            SceneManager.LoadScene("BonusLevel");

        }
        if (other.gameObject.tag == "BonusLevel_2")
        {
            distance = distanceCounter;
            gameObject.GetComponent<MoveHero>().enabled = false;
            gameObject.transform.position = new Vector3(0, 0.5f, -2.6f);
            gameObject.GetComponent<BonusMove_2>().enabled = true;
            SceneManager.LoadScene("BonusLevel_2");
        }
        if (other.gameObject.tag == "BonusLevel_3")
        {
            distance = distanceCounter;
            gameObject.GetComponent<MoveHero>().enabled = false;
            gameObject.transform.position = new Vector3(2, 3.5f, -5.1f);
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            gameObject.GetComponent<BonusMove_3>().enabled = true;
            SceneManager.LoadScene("BonusLevel_3");
        }
        if (other.gameObject.tag == "BonusLevel_4")
        {
            distance = distanceCounter;
            gameObject.GetComponent<MoveHero>().enabled = false;
            gameObject.transform.position = new Vector3(0, 0, -2);
            gameObject.GetComponent<BonusMove_4>().enabled = true;
            SceneManager.LoadScene("BonusLevel_4");
        }
    }
    
    void SetText()
    {
        goldCount.text = "" + coinCounter.ToString();
    }
    void SetText_2()
    {
        distanceCount.text = "" + distanceCounter.ToString();
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.38f);
        xMove = 0;
        lockMove = "no";
    }
}
