using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    public Transform FirstPlatform;
    public Transform SecondPlatform;
    public Transform ThirdPlatform;
    public Transform FourthPlatform;
    public Transform FifthPlatform;
    public Transform BonusPlatform;
    public Transform BonusPlatform_2;
    public Transform BonusPlatform_3;
    public Transform BonusPlatform_4;
    public int zPos = 279;
    public float chekPosNum = 1;
    public int randNum = 1;
    public int secRandNum = 1;
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
        chekPosNum -= Time.deltaTime - 0.011f;
        if (chekPosNum < 0)
        {
            randNum = Random.Range(1, 5);
            secRandNum = Random.Range(1, 15);
            if (secRandNum == 1)
            {
                Instantiate(BonusPlatform, new Vector3(-10.98f, -28.691f, zPos), BonusPlatform.rotation);
            }
            else if (secRandNum == 2)
            {
                Instantiate(BonusPlatform_2, new Vector3(-10.98f, -28.691f, zPos), BonusPlatform_2.rotation);
            }
            else if (secRandNum == 3)
            {
                Instantiate(BonusPlatform_3, new Vector3(-10.98f, -28.691f, zPos), BonusPlatform_3.rotation);
            }

            else if (secRandNum == 4)
            {
                Instantiate(BonusPlatform_4, new Vector3(-10.98f, -28.691f, zPos), BonusPlatform_4.rotation);
            }
            else
            {
                if (randNum == 1)
                {
                    Instantiate(FirstPlatform, new Vector3(-10.98f, -28.691f, zPos), FirstPlatform.rotation);
                }
                if (randNum == 2)
                {
                    Instantiate(SecondPlatform, new Vector3(-10.98f, -28.691f, zPos), SecondPlatform.rotation);
                }
                if (randNum == 3)
                {
                    Instantiate(ThirdPlatform, new Vector3(-10.98f, -28.691f, zPos), ThirdPlatform.rotation);
                }
                if (randNum == 4)
                {
                    Instantiate(FourthPlatform, new Vector3(-10.98f, -28.691f, zPos), FourthPlatform.rotation);
                }
                if (randNum == 5)
                {
                    Instantiate(FifthPlatform, new Vector3(-10.98f, -28.691f, zPos), FifthPlatform.rotation);
                }
            }
            if(changeSpeed == 1)
            {
                MoveHero.zMove = 30;
            }
            if (changeSpeed == 10)
            {
                    MoveHero.zMove += 10;
            }
            zPos += 120;
            chekPosNum = 1;
            changeSpeed++;
        }
        if(lvlStatus == "Fail")
        {
            load += Time.deltaTime;
        }
        if(load > 1)
        {
            SceneManager.LoadScene("Score");
        }
    }
}
