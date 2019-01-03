using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour {

    public GameObject ui;
    public GameObject objToTP;
    public Transform tpLoc;

	// Use this for initialization
	void Start () {
        ui.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        //so humands dont enable the teleport function
        if (col.tag == "Player")
        {
            ui.SetActive(true);
        }
        //Debug.Log(objToTP.gameObject.tag);
        if (Input.GetKeyDown(KeyCode.F) && col.tag == "Player")
        {
            objToTP.transform.position = tpLoc.transform.position;
        }
    }
    private void OnTriggerExit2D () {
        ui.SetActive(false);
	}
    private void Update()
    {
        if (objToTP.GetComponent<Rigidbody2D>().IsSleeping())
        {
            objToTP.GetComponent<Rigidbody2D>().WakeUp();
        }
    }
}
