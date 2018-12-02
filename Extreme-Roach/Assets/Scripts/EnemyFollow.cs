using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    public float radius = 2.5f;
    private Transform playerPos;
    private Player player;
    private Transform humanP;
    private Player human;

    //animation
    public Animator anim;

    //For rotation
    private Vector3 v_diff;
    private float atan2;

    //Respawning
    public Transform StartState;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim.SetTrigger("HumanIdle");
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(transform.position, playerPos.position) < radius)
        {
            GetComponentInChildren<Animator>().SetBool("isWalking", true);
            //rotating the human
            v_diff = (playerPos.position - transform.position);
            atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
            transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg - 90);

            //change Animation
            anim.SetTrigger("HumanWalk");

            //moving to target
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("isWalking", false);
            //restarting the animation
            anim.gameObject.SetActive(false); //(problem) stops Idle animation completely
            anim.gameObject.SetActive(true);
        }
        }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Roach loses health
            player.health--;
            //Moves Roach to respawn Position
            playerPos.transform.position = StartState.transform.position;
            //Roach dies
            if (player.health == 0) { 
                //Roach dies
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
