using System.Collections;
using UnityEngine;

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
        ui.SetActive(true);
        Debug.Log(objToTP.gameObject.tag);
        if ((objToTP.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
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
            objToTP.GetComponent<Rigidbody2D>().WakeUp();
    }
}
