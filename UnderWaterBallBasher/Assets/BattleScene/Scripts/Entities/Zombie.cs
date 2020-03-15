using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy {

    Vector2 speed;

    private void Start() {
        base.Awake(); //this is how you call the damn parent stuff smh
        name = "Zombie";
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(5, 5);
        rb.velocity = speed;
    }

    private void FixedUpdate() {
        base.Update();
        Movement(speed); 
        Fire();
    }
}
