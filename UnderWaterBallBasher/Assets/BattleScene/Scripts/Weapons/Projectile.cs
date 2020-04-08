using UnityEngine;

public class Projectile : MonoBehaviour {
    protected Rigidbody2D rb;
    protected float x, y;
    protected Vector2 speed;


    protected void ProjectileUpdate (Vector2 _speed) {
        var tmp = _speed * (rb.velocity.normalized);
        if (tmp.x > 0 && tmp.x < 1) {
            tmp.x = 1;
        }
        if (tmp.x < 0 && tmp.x > -1) {
            tmp.x = -1;
        }
        rb.velocity = tmp;
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