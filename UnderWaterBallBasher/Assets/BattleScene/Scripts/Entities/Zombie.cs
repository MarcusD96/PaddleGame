using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy {

    Vector2 speed;

    private void Awake() {
        name = "Zombie";
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(5, 5);
        rb.velocity = speed;
        SetHP(5);
    }

    private void FixedUpdate() {
        base.Update();
        Movement(speed); 
        Fire();
    }
}
