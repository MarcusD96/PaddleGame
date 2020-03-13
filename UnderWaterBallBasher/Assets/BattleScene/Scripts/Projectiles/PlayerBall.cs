using UnityEngine;
using TMPro;

public class PlayerBall : Projectile {

    public TextMeshProUGUI comboNum;
    private int COMBO;
    private Enemy EnemyHolder;
    private Paddle PlayerHolder;

    private void Start () {
        tag = "Ball";
        name = "Player Ball";

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
        rb.AddTorque(3);
        COMBO = 0;

        foreach(var c in FindObjectsOfType<TextMeshProUGUI>()) {
            if(c.CompareTag("Combo")) {
                comboNum = c;
            }
        }

        PlayerHolder = FindObjectOfType<Paddle>();
        EnemyHolder = FindObjectOfType<Enemy>();

        comboNum.text = "COMBO: " + COMBO;
    }

    // Update is called once per frame
    private void Update() {
        ProjectileUpdate(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        switch(collision.gameObject.tag) {
            case "Paddle":  //ball hits paddle
                SoundManager.PlaySound("BallPaddle");
                COMBO += 1;
                break;

            case "BallSideBad": //ball hits enemy side wall
                SoundManager.PlaySound("BallBad");
                COMBO = 0;
                PlayerHolder.TakeHit(1);
                break;

            case "BallSide":    //ball hits player side wall
                SoundManager.PlaySound("BallWall");
                break;
            case "Enemy":
                SoundManager.PlaySound("BallWall");
                break;
            case "EnemySide":
                SoundManager.PlaySound("BallWall");
                EnemyHolder.ReduceHP(1);
                break;
            default:
                break;
        }
        comboNum.text = "COMBO: " + Mathf.Clamp(COMBO, 0, 10);
        speed = new Vector2(x + COMBO, y + COMBO);
    }
}
