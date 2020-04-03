using UnityEngine;

public class Zombie : Enemy {

    Vector2 speed;

    private void Awake() {
        name = "Zombie";
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(3, 3);
        rb.velocity = speed;
        SetHP(Random.Range(2, 5));
    }

    private void FixedUpdate() {
        base.Update();
        Movement(speed);
        Fire();
    }
}
