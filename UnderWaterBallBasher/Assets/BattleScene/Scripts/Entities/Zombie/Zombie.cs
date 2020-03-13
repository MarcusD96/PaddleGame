using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy {

    Vector2 speed;

    private void Start() {
        name = "Zombie";
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(5, 5);
        rb.velocity = speed;
    }

    private void Update() {
        Movement(speed);
        Fire();
    }
}
