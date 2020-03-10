using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBall : Projectile {

    // Start is called before the first frame update
    private void Start() {
        if (x == 0) {
            x = -3;
        }
        if (y == 0) {
            y = 0;
        }
        constantSpeed = new Vector2(x, y);
        rb = GetComponent<Rigidbody2D>();
        tag = "Projectile";
        name = "Rock";

        rb.velocity = new Vector2(x, y);
        rb.AddTorque(3.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.gameObject.tag) {
            case "Paddle":  //ball hits paddle
                SoundManager.PlaySound("BallBad");
                collision.gameObject.GetComponent<Paddle>().TakeHit(1);
                Destroy(gameObject);
                break;

            case "BallSideBad": //ball hits enemy side wall
                SoundManager.PlaySound("BallWall");
                Destroy(gameObject);
                break;

            case "BallSide":    //ball hits player side wall
                SoundManager.PlaySound("BallWall");
                Destroy(gameObject);
                break;

            case "Ball":    //ball hits ball
                SoundManager.PlaySound("BallWall");
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }
}
