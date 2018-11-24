using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    public float radius = 1f;

    private Rigidbody2D myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;

    private Transform target;
    private Player player;

    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        myRigidbody = GetComponent<Rigidbody2D>();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }
	
	// Update is called once per frame
	void Update () {
        
        //Roach dies
        if(Vector2.Distance(transform.position, target.position) < radius)
        {
            moving = true;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        //
 //       if (moving)
 //       {
 //           timetomovecounter -= time.deltatime;
 //           myrigidbody.velocity = movedirection;
//
 //           if(timebetweenmovecounter > 0)
 //           {
 //              moving = false;
 //               timebetweenmovecounter = timebetweenmove;
 //           }
 //               
 //       }
 //       else
 //        {
 //           timebetweenmovecounter -= time.deltatime;
 //           myrigidbody.velocity = vector2.zero;
 //           if(timebetweenmovecounter< 0f)
 //           {
 //               moving = true;
 //               timetomovecounter = timetomove;
                
 //               movedirection = new vector3(random.range(-1f, 1f) * speed, random.range(-1f, 1f) * speed, 0f);
 //           }
 //       }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.helth--;

        }
    }
}
