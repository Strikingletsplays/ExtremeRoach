using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    public float radius = 1f;
    private Transform playerPos;
    private Player player;

    // direction
    private Vector3 v_diff;
    private float atan2;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(Vector2.Distance(transform.position, playerPos.position) < radius)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

            //rotating the human
            //transform.LookAt(playerPos.position, transform.up);
            v_diff = (playerPos.position - transform.position);
            atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
            transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
        }
    }

    void OnTriggerEnter2D(Collider2D other )
    {
        if (other.CompareTag("Player"))
        {
            //Roach dies
            //player.helth--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
