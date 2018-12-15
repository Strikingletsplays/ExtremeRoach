using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{

    public GameObject roach1, roach2, roach3, gameOver;



    public static int health;

    void Start()
    {
        health = 3;
        roach1.gameObject.SetActive(true);
        roach2.gameObject.SetActive(true);
        roach3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

    }

    void Update()
    {
        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                roach1.gameObject.SetActive(true);
                roach2.gameObject.SetActive(true);
                roach3.gameObject.SetActive(true);
                break;
            case 2:
                roach1.gameObject.SetActive(true);
                roach2.gameObject.SetActive(true);
                roach3.gameObject.SetActive(false);
                break;
            case 1:
                roach1.gameObject.SetActive(true);
                roach2.gameObject.SetActive(false);
                roach3.gameObject.SetActive(false);
                break;
            case 0:
                roach1.gameObject.SetActive(false);
                roach2.gameObject.SetActive(false);
                roach3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }



}
