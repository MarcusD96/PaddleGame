using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour {
    public Rigidbody2D rb;

    public float x, y;
    public Vector2 constantSpeed;
    public void BallStart () {
        //name = "Ball";
        //rb = GetComponent<Rigidbody2D>();
        //constantSpeed = new Vector2(x, y);
        //rb.velocity = constantSpeed;
    }
    public void BallUpdate (Vector2 speed) {
        rb.velocity = speed * (rb.velocity.normalized);
    }
}