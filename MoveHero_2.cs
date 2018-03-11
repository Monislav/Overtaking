using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveHero_2 : MonoBehaviour {
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public int laneNum = 3;
    public static float zMove = 20;
    public static float xMove = 0;
    public string lockMove = "no";
    public static string stopMove = "no";
    public Text goldCount;
    public int coinCounter;
    public int coinBalance;
    public AudioClip impact;
    public Camera firstCamera;
    public Camera secondCamera;
    public static int coins;

    // Use this for initialization
    void Start()
    {
        firstCamera.enabled = true;
        secondCamera.enabled = false;
        coinBalance = PlayerPrefs.GetInt("totalCoins");
        coinCounter = 0;
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(xMove, 0, zMove);
        if (Input.GetKeyDown(moveLeft) && (laneNum > 1) && (lockMove == "no"))
        {
            xMove = -11.5f;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            lockMove = "yes";
        }
        if (Input.GetKeyDown(moveRight) && (laneNum <= 3) && (lockMove == "no"))
        {
            xMove = 11.5f;
            StartCoroutine(stopSlide());
            laneNum += 1;
            lockMove = "yes";
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firstCamera.enabled = !firstCamera.enabled;
            secondCamera.enabled = !secondCamera.enabled;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            stopMove = "yes";
            Platform_2.lvlStatus = "Fail";
            coinBalance += coinCounter;
            PlayerPrefs.SetInt("totalCoins", coinBalance);
            coinCounter = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            AudioSource.PlayClipAtPoint(impact, transform.position);
            Destroy(other.gameObject);
            coinCounter++;
            MoveHero.coinCounter++;
            coins++;
            SetText();
        }
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.42f);
        xMove = 0;
        lockMove = "no";
    }
    void SetText()
    {
        goldCount.text = "" + coinCounter.ToString();
    }
}
