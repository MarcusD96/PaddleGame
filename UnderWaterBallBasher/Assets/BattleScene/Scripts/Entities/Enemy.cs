using System.Runtime.InteropServices; //using dll's
using UnityEngine;

public class Enemy : BaseEntity {

    protected float fireRate, nextFire = 1.0f;

    public Transform turret;
    public GameObject ball;
    public PlayerBall ballHolder;
    protected Rigidbody2D rb;

    [DllImport("TestAI", CallingConvention = CallingConvention.Cdecl)] public static extern float FollowB(float _BY, float _EY, float _Sped);

    protected virtual void Update() {
        if(ballHolder == null) {
            ballHolder = FindObjectOfType<PlayerBall>();
        }

        else if (ballHolder.transform.position.x >= gameObject.transform.position.x) {
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
        if(Time.timeSinceLevelLoad > nextFire) {
            Instantiate(ball, turret.position, Quaternion.identity);
            nextFire = Time.timeSinceLevelLoad + fireRate;
        }
    }

    public void ReduceHealth(int n) {
        hp -= n;
    }

    public void Movement(Vector2 speed) {
        if(ballHolder != null) {
            var tmp = new Vector2(rb.velocity.x, FollowB(ballHolder.gameObject.transform.position.y, gameObject.transform.position.y, speed.y));
            if(tmp.x > 0 && tmp.x < 1) {
                tmp.x = 1;
            }
            if(tmp.x < 0 && tmp.x > -1) {
                tmp.x = -1;
            }
            rb.velocity = tmp;
        }
        rb.velocity = speed * rb.velocity.normalized;
    }
}