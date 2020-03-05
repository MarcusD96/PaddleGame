using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices; //using dll's
using UnityEngine;

public class Enemy : BaseEntity {

    public float x, y, rand2, fireRate = 3.0f, nextFire = 0.0f;
    public bool isShootingAndMoving, hasShot;

    protected Vector2 constantSpeed;
    public Transform turret;
    public GameObject ball;
    protected Rigidbody2D rb;

    private void Awake() {
        Init();
        rb.velocity = constantSpeed;
    }

    private void FixedUpdate() {
        Movement();
        Fire();
    }

    public void Init() {
        name = "Enemy";
        tag = "Enemy";

        SetHP(5);

        rb = GetComponent<Rigidbody2D>();

        x = 5;
        y = 5;
        constantSpeed = new Vector2(x, y);
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

    public void Movement() {
        rb.velocity = constantSpeed * (rb.velocity.normalized);
    }
}