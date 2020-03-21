using System.Runtime.InteropServices; //using dll's
using UnityEngine;

public class Enemy : BaseEntity {

    public float fireRate = 3.0f, nextFire = 3.0f;

    public Transform turret;
    public GameObject ball;
    public PlayerBall ballHolder;
    protected Rigidbody2D rb;

    protected virtual void Update() {
        if(ballHolder == null) {
            ballHolder = FindObjectOfType<PlayerBall>();
        }

        else if (ballHolder.transform.position.x > gameObject.transform.position.x) {
            Physics2D.IgnoreCollision(ballHolder.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        } else {
            Physics2D.IgnoreCollision(ballHolder.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        switch(collision.gameObject.tag) {
            case "EnemySide":
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                break;
            case "NML":
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                break;
            default:
                break;
        }
    }

    public void Fire() {
        if(Time.time > nextFire) {
            Instantiate(ball, turret.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void ReduceHealth(int n) {
        hp -= n;
    }

    [DllImport("TestAI", CallingConvention = CallingConvention.Cdecl)]
    public static extern float FollowB(float _BY, float _EY, float _Sped);

    public void Movement(Vector2 speed) {
        if(ballHolder != null) {
            rb.velocity = new Vector2(rb.velocity.x, FollowB(ballHolder.gameObject.transform.position.y, gameObject.transform.position.y, speed.y));
        }
        rb.velocity = speed * rb.velocity.normalized;
    }
}