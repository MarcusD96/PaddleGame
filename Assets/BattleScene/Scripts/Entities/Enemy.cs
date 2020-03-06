using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices; //using dll's
using UnityEngine;

public class Enemy : BaseEntity {

    public float fireRate = 3.0f, nextFire = 3.0f;

    public Transform turret;
    public GameObject ball;
    protected Rigidbody2D rb;

    private void Awake() {
        Init();
    }

    private void Update() {
        Movement(new Vector2(5, 5));
    }

    public void Init() {
        name = "Enemy";
        tag = "Enemy";

        SetHP(5);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        switch(collision.gameObject.tag) {
            case "EnemySide":
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                break;
            case "NML":
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                break;
            default:
                break;
        }
    }

    public void Fire() {
        if(Time.time > nextFire) {
            Instantiate(ball, turret.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void ReduceHealth(int n) {
        hp -= n;
    }

    public void Movement(Vector2 speed) {
        rb.velocity = speed * rb.velocity.normalized; 
    }
}