using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : Projectile {

    // Start is called before the first frame update
    void Start () {
        if(x == 0) {
            x = 3;
        }
        if(y == 0) {
            y = 0;
        }

        BallStart();

        rb.velocity = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update () {
        BallUpdate();
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if(collision.gameObject.tag == "Enemy") {
            SoundManager.PlaySound("BallBad");
            Destroy(gameObject);
        }
    }
}
