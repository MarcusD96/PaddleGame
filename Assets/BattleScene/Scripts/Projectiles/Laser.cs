using UnityEngine;

public class Laser : Projectile {
    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        if (x == 0) {
            x = 10;
        }
        if (y != 0) {
            y = 0;
        }
        speed = new Vector2(x, y);
        rb.velocity = speed;
    }

    // Update is called once per frame
    private void Update() {
        ProjectileUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.gameObject.tag) {
            case "BallSide":    //ball hits player side wall
                Destroy(gameObject);
                break;
            case "Enemy":
                SoundManager.PlaySound("BallWall");
                Destroy(gameObject);
                collision.gameObject.GetComponent<Enemy>().ReduceHP(1);
                break;
            default:
                break;
        }
    }
}
