﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBall : Projectile {

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        if (x == 0) {
            x = -3;
        }
        if (y == 0) {
            y = 0;
        }
        speed = new Vector2(x, y);

        name = "Rock";

        rb.velocity = speed;
        rb.AddTorque(3.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch(collision.gameObject.tag) {
            case "Paddle":  //ball hits paddle
                collision.gameObject.GetComponent<Paddle>().TakeHit(1);
                Destroy(gameObject);
                break;

            case "BallSideBad": //ball hits enemy side wall
                Destroy(gameObject);
                break;

            case "BallSide":    //ball hits player side wall
                Destroy(gameObject);
                break;

            case "Ball":    //ball hits ball
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }
}
