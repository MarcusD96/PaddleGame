using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealtSystem : MonoBehaviour {

    public Canvas canvas;
    public Transform heart;

    public Transform heartSpawner;
    private Transform[] hearts;
    private int playerHealth;
    private int playerHeartNum;

    public Transform enemyHeartSpawner;
    private Transform[] enemyHearts;
    private int enemyHealth;
    private int enemyHeartNum;

    /* Start is called before the first frame update*/
    private void Start() {
        hearts = new Transform[FindObjectOfType<Paddle>().GetHP()];
        enemyHearts = new Transform[FindObjectOfType<Enemy>().GetHP()];

        MakeHearts();
    }

    /* Update is called once per frame*/
    private void Update() {
        UpdateHearts();
    }

    private void MakeHearts() {
        Vector2 temp;

        playerHealth = FindObjectOfType<Paddle>().GetHP();
        playerHeartNum = FindObjectOfType<Paddle>().GetHP() - 1;

        for (int i = 0; i < playerHealth; ++i) {
            temp.x = heartSpawner.position.x + (1 * i);
            temp.y = heartSpawner.position.y;
            hearts[i] = Instantiate(heart, temp, Quaternion.identity, canvas.transform);
        }


        enemyHealth = FindObjectOfType<Enemy>().GetHP();
        enemyHeartNum = FindObjectOfType<Enemy>().GetHP() - 1;

        for (int i = 0; i < enemyHealth; ++i) {
            temp.x = enemyHeartSpawner.position.x + (-1 * i);
            temp.y = enemyHeartSpawner.position.y;
            enemyHearts[i] = Instantiate(heart, temp, Quaternion.identity, canvas.transform);
        }
    }

    private void UpdateHearts() {
        playerHealth = FindObjectOfType<Paddle>().GetHP();

        //if (PlayerHealth == 0) {
        //    FindObjectOfType<Paddle>().SetHP(5);
        //    FindObjectOfType<Enemy>().SetHP(5);
        //    MakeHearts();
        //}
        //else if
        if (playerHealth - 1 < playerHeartNum) {
            Destroy(hearts[playerHeartNum].gameObject);
            playerHeartNum--;
        }

        enemyHealth = FindObjectOfType<Enemy>().GetHP();

        //if (EnemyHealth == 0) {
        //    FindObjectOfType<Paddle>().SetHP(5);
        //    FindObjectOfType<Enemy>().SetHP(5);
        //    MakeHearts();
        //}
        //else if
        if (enemyHealth - 1 < enemyHeartNum) {
            Destroy(enemyHearts[enemyHeartNum].gameObject);
            enemyHeartNum--;
        }
    }
}