using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class carmove : MonoBehaviour {

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    private Player player;
    private Transform playerPos;
    public Transform StartState;

    // Use this for initialization
    void Start() {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints [0];
        
        //Player control (for killing and changing health)
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        // check to see if we have reached the patrol point
        if (Vector2.Distance(transform.position, currentPatrolPoint.position) < .1f)
        {
            //Debug.Log(currentPatrolIndex);
            //we have reached the patrol point - get the next one
            //check to see if we have anymore patrol points - if not go back to the beginning
            if (currentPatrolIndex  < patrolPoints.Length)
            {
                currentPatrolIndex++; 
            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }
        // turn to face the current patrol point
        //finding the direction vector that points to the patrolpoint
        Vector2 patrolPointDir = currentPatrolPoint.position - transform.position;
        // figure out the rotation in degrees that we need to turn towards
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;
        //made the rotation that we need to face
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        // apply the rotation to out transform

        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
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
            if (player.health == 0)
            {
                //Roach dies
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}
