using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusMove_2 : MonoBehaviour {
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public int laneNum = 2;
    public float xMove = 0;
    public string lockMove = "no";
    public static string stopMove = "no";
    public AudioClip impact;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        MoveHero.distanceCounter = (int)transform.position.z;
        GetComponent<Rigidbody>().velocity = new Vector3(xMove, 0, 28);
        if (Input.GetKeyDown(moveLeft) && (laneNum > 1) && (lockMove == "no"))
        {
            xMove = -7.2f;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            lockMove = "yes";
        }
        if (Input.GetKeyDown(moveRight) && (laneNum <= 2) && (lockMove == "no"))
        {
            xMove = 7.2f;
            StartCoroutine(stopSlide());
            laneNum += 1;
            lockMove = "yes";
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            stopMove = "yes";
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            AudioSource.PlayClipAtPoint(impact, transform.position);
            Destroy(other.gameObject);
            MoveHero.coinCounter += 5;
            MoveHero.coins += 5;
        }
        if(other.gameObject.tag == "Exit")
        {
            gameObject.GetComponent<BonusMove_2>().enabled = false;
            gameObject.transform.position = new Vector3(0, 0, 0);
            gameObject.GetComponent<MoveHero>().enabled = true;
            SceneManager.LoadScene("Level");
        }
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.38f);
        xMove = 0;
        lockMove = "no";
    }
}
