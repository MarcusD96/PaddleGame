using UnityEngine;

public class Projectile : MonoBehaviour {
    protected Rigidbody2D rb;
    protected float x, y;
    protected Vector2 speed;

    protected void ProjectileUpdate () {
        rb.velocity = speed * (rb.velocity.normalized);
    }
}