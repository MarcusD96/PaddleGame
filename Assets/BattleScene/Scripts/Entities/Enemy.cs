using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEntity {

    public float x, y, rand2, fireRate = 3.0f, nextFire = 0.0f;
    public bool isShootingAndMoving, hasShot;

    private Vector2 constantSpeed;
    private System.Random rand = new System.Random();
    public Transform turret;
    public GameObject Ball;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    public void Init() {
        name = "Enemy";
        tag = "Enemy";
        SetHP(5);
        rb = GetComponent<Rigidbody2D>();

        rb = GetComponent<Rigidbody2D>();
        x = 5;
        y = 5;
        constantSpeed = new Vector2(x, y);

        Movement();
        //by making the velocities const initially, it took away the 'shaking'
    }

    public void OnTriggerEnter2D(Collider2D collision) //collide with seprating wall between player and enemy side
    {
        switch (collision.gameObject.tag) {
            case "EnemySide":
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                break;
            default:
                break;
        }
    }

    public void Fire() {
        if (Time.time > nextFire) {
            Instantiate(Ball, turret.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void ReduceHealth(int n) {
        hp -= n;
    }

    public void Movement() {
        if (hasShot == true && isShootingAndMoving == true) {

            rb.velocity = constantSpeed;
            rb.velocity = constantSpeed * (rb.velocity.normalized);
        }
    }
}