using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Player player;
    public GameObject health1, health2, health3;
    public int health = 3;
    public Text healthText;
    public Text into;

    // Use this for initialization
    void Start () {
        health1.gameObject.SetActive(true);
        health2.gameObject.SetActive(true);
        health3.gameObject.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
       // healthText.text = "Health: " + health;

        switch (health)
        {
            case 3:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                break;
            case 2:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(false);
                break;
            case 1:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(false);
                health3.gameObject.SetActive(false);
                break;
            case 0:
                health1.gameObject.SetActive(false);
                health2.gameObject.SetActive(false);
                health3.gameObject.SetActive(false);
               // gameOver.gameObject.SetActive(true);
                break;
        }
    }
    
}
