using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBall : Projectile {

    public TextMeshProUGUI comboNum;
    private int COMBO;

    void Start () {
        if(x == 0) {
            x = 5;
        }
        if(y == 0) {
            y = 5;
        }
        BallStart();
        tag = "Ball";
        COMBO = 0;
        foreach(var c in FindObjectsOfType<TextMeshProUGUI>()) {
            if(c.CompareTag("Combo")) {
                comboNum = c;
            }
        }
        comboNum.text = "COMBO: " + COMBO;
    }

    // Update is called once per frame
    void Update () {
        BallUpdate();
    }

    void OnCollisionEnter2D (Collision2D collision) {
        switch(collision.gameObject.tag) {
            case "Paddle":  //ball hits paddle
                SoundManager.PlaySound("BallPaddle");
                constantSpeed = new Vector2(x + COMBO, y + COMBO);
                break;

            case "BallSideBad": //ball hits enemy side wall
                SoundManager.PlaySound("BallBad");
                COMBO = 0;
                comboNum.text = "COMBO: " + COMBO;
                constantSpeed = new Vector2(x + COMBO, y + COMBO);
                break;

            case "BallSide":    //ball hits player side wall
                SoundManager.PlaySound("BallWall");
                break;
            case "Enemy":
                SoundManager.PlaySound("BallWall");
                COMBO += 1;
                comboNum.text = "COMBO: " + COMBO;
                constantSpeed = new Vector2(x + COMBO, y + COMBO);
                collision.gameObject.GetComponent<Enemy>().ReduceHealth(1);
                FindObjectOfType<GaugeBar>().UpdateEnemyHealth(.1f);

                break;

            default:
                break;
        }
    }
}
