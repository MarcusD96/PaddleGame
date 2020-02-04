using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBall : Ball
{

    public Text ComboNum;
    private int COMBO;

    void Start()
    {
        if (x == 0)
        {
            x = 5;
        }
        if (y == 0)
        {
            y = 5;
        }
        BallStart();
        tag = "Ball";
        COMBO = 0;
        ComboNum = FindObjectOfType<Text>();
        ComboNum.text = "COMBO: " + COMBO;
    }

    // Update is called once per frame
    void Update()
    {
        BallUpdate();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Paddle":  //ball hits paddle
                SoundManager.PlaySound("BallPaddle");
                COMBO += 1;
                ComboNum.text = "COMBO: " + COMBO;
                constantSpeed = new Vector2(x + COMBO, y + COMBO);
                Debug.Log(COMBO);
                break;

            case "BallSideBad": //ball hits enemy side wall
                SoundManager.PlaySound("BallBad");
                COMBO = 0;
                ComboNum.text = "COMBO: " + COMBO;
                constantSpeed = new Vector2(x + COMBO, y + COMBO);
                break;

            case "BallSide":    //ball hits player side wall
                SoundManager.PlaySound("BallWall");
                break;
            case "Enemy":
                SoundManager.PlaySound("BallWall");
                FindObjectOfType<GaugeBar>().UpdateEnemyHealth(.1f);

                break;

            default:
                break;
        }
    }
}
