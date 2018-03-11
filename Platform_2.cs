using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform_2 : MonoBehaviour {

    public Transform FirstPlatform;
    public Transform SecondPlatform;
    public Transform ThirdPlatform;
    public Transform FourthPlatform;
    public int zPos = 198;
    public float chekPosNum = 1;
    public int randNum = 1;
    public int changeSpeed = 0;
    public static string lvlStatus = "";
    public float load = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chekPosNum -= Time.deltaTime - 0.010f;
        if (chekPosNum < 0)
        {
            randNum = Random.Range(1, 4);
            if (randNum == 1)
            {
                Instantiate(FirstPlatform, new Vector3(-18.103f, -29.971f, zPos), FirstPlatform.rotation);
            }
            if (randNum == 2)
            {
                Instantiate(SecondPlatform, new Vector3(-18.103f, -29.971f, zPos), SecondPlatform.rotation);
            }
            if (randNum == 3)
            {
                Instantiate(ThirdPlatform, new Vector3(-18.103f, -29.971f, zPos), ThirdPlatform.rotation);
            }
            if (randNum == 4)
            {
                Instantiate(FourthPlatform, new Vector3(-18.103f, -29.971f, zPos), FourthPlatform.rotation);
            }
            if (changeSpeed == 1)
            {
                MoveHero_2.zMove = 30;
            }
            if (changeSpeed == 25)
            {
                MoveHero_2.zMove += 10;
            }
            zPos += 119;
            chekPosNum = 1;
            changeSpeed++;
        }
        if (lvlStatus == "Fail")
        {
            load += Time.deltaTime;
        }
        if (load > 1)
        {
            SceneManager.LoadScene("Score");
        }
    }
}
