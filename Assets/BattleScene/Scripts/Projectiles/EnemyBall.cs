using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBall : Projectile {



    // Start is called before the first frame update
    void Start() {
        if (x == 0) {
            x = -3;
        }
        if (y == 0) {
            y = 0;
        }

        BallStart();
        tag = "Projectile";

        rb.velocity = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update() {
        //BallUpdate();

    }

    void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.gameObject.tag) {
            case "Paddle":  //ball hits paddle
                SoundManager.PlaySound("BallBad");
                collision.gameObject.GetComponent<Paddle>().ReduceHP(1);
                Destroy(gameObject);
                break;

            case "BallSideBad": //ball hits enemy side wall
                SoundManager.PlaySound("BallWall");
                Destroy(gameObject);
                break;

            case "BallSide":    //ball hits player side wall
                SoundManager.PlaySound("BallWall");
                Destroy(gameObject); ///dont need GameObject.Destroy, just Destroy
                break;

            case "Ball":    //ball hits ball
                SoundManager.PlaySound("BallWall");
                Destroy(gameObject); ///here too
                break;

            default:
                break;
        }
    }
}
