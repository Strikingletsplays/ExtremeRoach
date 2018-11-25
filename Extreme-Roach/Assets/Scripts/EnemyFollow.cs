using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    public float radius = 1f;
    private Transform playerPos;
    private Player player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        
        //Roach dies
        if(Vector2.Distance(transform.position, playerPos.position) < radius)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other )
    {
        if (other.CompareTag("Player"))
        {
            //player lossing helth
            player.helth--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
