using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class carmove : MonoBehaviour {

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    // Use this for initialization
    void Start() {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints [currentPatrolIndex];
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        // check to see if we have reached the patrol point
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f)
        {
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
            currentPatrolPoint = patrolPoints[currentPatrolIndex];        }
        // turn to face the current patrol point
        //finding the direction vector that points to the patrolpoint
        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        // figure out the rotation in degrees that we need to turn towards
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;
        //made the rotation that we need to face
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        // apply the rotation to out transform

        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
    }

    
}
