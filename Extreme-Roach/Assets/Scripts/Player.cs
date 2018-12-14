using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    float dirX, dirY;
    Rigidbody2D rb;
    public float moveSpeed = 2f;

    void Start() {

        rb = GetComponent<Rigidbody2D>();
}

    void Update() {

        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
    }


   
}
