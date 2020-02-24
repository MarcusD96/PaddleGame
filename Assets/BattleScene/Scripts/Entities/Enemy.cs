using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEntity {

    private float x, y, fireRate = 1f, nextFire = 0.0f;
    
    private Vector2 constantSpeed;
    private System.Random rand = new System.Random();
    public Transform turret;
    public GameObject Ball;

    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start () {
        name = "Enemy";
        tag = "Enemy";
        SetHP(5);
        rb = GetComponent<Rigidbody2D>();

        x = 5;
        y = 5;
        // by making the velocities const initially, it took away the 'shaking'
        constantSpeed = new Vector2(x, y);
        rb.velocity = constantSpeed;

    }

    // Update is called once per frame
    void Update () {
        rb.velocity = constantSpeed * (rb.velocity.normalized);
        Fire();
    }

    private void OnTriggerEnter2D (Collider2D collision) //collide with seprating wall between player and enemy side
    {
        switch(collision.gameObject.tag) {
            case "NML":
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                break;
            default:
                break;
        }
    }

    public void Fire () {
        if(Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(Ball, turret.position, Quaternion.identity);
        }
    }

    public void ReduceHealth(int n) {
        hp -= n;
    }
}