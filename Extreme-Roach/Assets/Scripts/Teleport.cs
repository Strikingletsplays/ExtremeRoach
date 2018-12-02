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

    private void OnTriggerStay2D()
    {
        ui.SetActive(true);
        if ((objToTP.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            objToTP.transform.position = tpLoc.transform.position;
        }
    }
    private void OnTriggerExit2D () {
        ui.SetActive(false);
	}
}
