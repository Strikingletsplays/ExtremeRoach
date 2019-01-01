using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Player player;
    public GameObject health1, health2, health3;
    public GameObject EndObject;
    public int health = 3;
    public int foodobj;
    public Text status;

    // Use this for initialization
    void Start () {
        health1.gameObject.SetActive(true);
        health2.gameObject.SetActive(true);
        health3.gameObject.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        EndObject = GameObject.FindGameObjectWithTag("EndObject");
        foodobj = 3;
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

        //if food collected
        if (foodobj == 0 || foodobj < 0)
        {
            status.text = "Go to the construction site! (HINT: Find the flag!!)";
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("EndObject"))
        {
            if (foodobj == 0 || foodobj < 0)
             SceneManager.LoadScene("Ending");
        }
    }

}
