using UnityEngine;
using TMPro;

public class PlayerBall : Projectile {

    public TextMeshProUGUI comboNum;
    private int COMBO;
    private Enemy EnemyHolder;
    private Paddle PlayerHolder;
    private Collider2D TempCol;

    private SoundManager sound;

    private void Start() {
        tag = "Ball";
        name = "Player Ball";

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
        rb.AddTorque(3);
        COMBO = 0;

        foreach (var c in FindObjectsOfType<TextMeshProUGUI>()) {
            if (c.CompareTag("Combo")) {
                comboNum = c;
            }
        }

        sound = FindObjectOfType<SoundManager>();

        PlayerHolder = FindObjectOfType<Paddle>();
        EnemyHolder = FindObjectOfType<Enemy>();

        comboNum.text = "COMBO: " + COMBO;
    }

    // Update is called once per frame
    private void Update() {
        ProjectileUpdate(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.gameObject.tag) {
            case "Paddle":  //ball hits paddle                
                COMBO += 1;
                sound.Play("PaddleHitsBall");
                break;

            case "BallSideBad": //ball hits player side wall
                sound.Play("PlayerWallDamage");
                COMBO = 0;
                PlayerHolder.TakeHit(1);
                break;

            case "BallSide":    //ball hits other sides + corners
                //sound
                break;

            case "Enemy": //ball hits enemy
                //sound
                break;

            case "EnemySide": //ball hits enemy side
                sound.Play("EnemyWallDamage");
                EnemyHolder.ReduceHP(1);
                break;

            default:
                break;
        }
        if(comboNum) {
            comboNum.text = "COMBO: " + COMBO;
        }
        var i = 8 + GameState.GetStat((int)Stats.agressiveness);
        if (COMBO < i) {
            speed = new Vector2(x + COMBO, y + COMBO);
        } else if (COMBO >= i) {
            speed = new Vector2(x + i, y + i);
        }
    }
}
