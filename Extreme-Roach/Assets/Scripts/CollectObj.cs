using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObj : MonoBehaviour {

    //
    private Player player;
    public GameObject ui;
    public Text status;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ui.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        ui.SetActive(true);
        if (Input.GetKeyDown(KeyCode.F) && other.CompareTag("Player"))
        {
            player.foodobj--;
            Destroy(gameObject);
            ui.SetActive(false);
            status.text = "Objective: Grab " + player.foodobj + " food objects.";
        }
    }

    private void OnTriggerExit2D()
    {
        ui.SetActive(false);
    }
}
