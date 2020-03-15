using UnityEngine;

public class Projectile : MonoBehaviour {
    protected Rigidbody2D rb;
    protected float x, y;
    protected Vector2 speed;


    protected void ProjectileUpdate (Vector2 _speed) {
        rb.velocity = _speed * (rb.velocity.normalized);
        //rb.AddForce(speed);
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