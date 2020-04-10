using UnityEngine;

public class Zombie : Enemy {

    Vector2 speed;

    private void Awake() {
        name = "Zombie";
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(2, 3);
        rb.velocity = speed;
        fireRate = 2.0f;
        SetHP(Random.Range(2, 5));
    }

    private void FixedUpdate() {
        base.Update();
        Movement(speed);
        Fire();
    }
}
