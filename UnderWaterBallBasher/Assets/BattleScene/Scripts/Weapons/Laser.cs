﻿using UnityEngine;

public class Laser : Projectile {

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        if (x == 0) {
            x = 20;
        }
        if (y != 0) {
            y = 0;
        }
        speed = new Vector2(x, y);
        rb.velocity = speed;
    }

    // Update is called once per frame
    private void Update() {
        ProjectileUpdate(speed);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.gameObject.tag) {
            case "EnemySide":    //laser hits player side wall
                Destroy(gameObject);
                break;
            //case "Enemy":
            //    SoundManager.PlaySound("BallWall");
            //    Destroy(gameObject);
            //    collision.gameObject.GetComponent<Enemy>().ReduceHP(1, transform.position);
            //    break;
            case "Rock":
                Destroy(gameObject);
                Destroy(collision.gameObject);
                GameState.Points++;
                break;
            default:
                break;
        }
    }
}