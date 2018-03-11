using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusMove_4 : MonoBehaviour
{
    public float xMove;
    public float chek;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(xMove, 0, 20);
        if (Input.GetKeyDown(KeyCode.A))
        {
            xMove -= 7;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            xMove = 7;
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Score");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "100")
        {
            Destroy(other.gameObject);
            MoveHero.coinCounter += 100;
            MoveHero.coins += 100;
        }
        if (other.gameObject.tag == "Exit")
        {
            gameObject.GetComponent<BonusMove_4>().enabled = false;
            gameObject.transform.position = new Vector3(0, 0, 0);
            gameObject.GetComponent<MoveHero>().enabled = true;
            SceneManager.LoadScene("Level");
        }
    }
}
