using UnityEngine;

public class Projectile : MonoBehaviour {
    protected Rigidbody2D rb;
    public float x, y;
    protected Vector2 speed;


    protected void ProjectileUpdate (Vector2 _speed) {
        rb.velocity = _speed * (rb.velocity.normalized);
    }

    public void SetSpeed(Vector2 _speed) {
        x = _speed.x;
        y = _speed.y;
        speed = _speed;
    }

    public Rigidbody2D GetRigidbody2D() {
        return rb;
    }
}