using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : Projectile {

    // Start is called before the first frame update
    void Start() {
        if (x == 0) {
            x = 10;
        }
        if (y == 0) {
            y = 0;
        }

        BallStart();

        rb.velocity = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update() {
        BallUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.gameObject.tag) {
            case "BallSide":    //ball hits player side wall
                Destroy(gameObject);
                break;
            case "Enemy":
                SoundManager.PlaySound("BallWall");
                Destroy(gameObject);
                collision.gameObject.GetComponent<Enemy>().ReduceHP(1);
                break;
            default:
                break;
        }
    }
}
