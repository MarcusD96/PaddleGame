﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour {

    public Canvas canvas;
    public Transform Heart;

    public Transform HeartSpawner;
    public Transform[] Hearts = new Transform[FindObjectOfType<Paddle>().GetHP()];
    private int PlayerHealth;
    private int PlayerHeartNum;

    public Transform EnemyHeartSpawner;
    public Transform[] EnemyHearts = new Transform[FindObjectOfType<Enemy>().GetHP()];
    private int EnemyHealth;
    private int EnemyHeartNum;

    /* Start is called before the first frame update*/
    void Start() {
        MakeHearts();
    }

    /* Update is called once per frame*/
    void Update() {
        UpdateHearts();
    }

    void MakeHearts() {
        Debug.Log("Make Hearts");
        Vector2 Temp;

        PlayerHealth = FindObjectOfType<Paddle>().GetHP();
        PlayerHeartNum = FindObjectOfType<Paddle>().GetHP() - 1;

        for (int i = 0; i < PlayerHealth; ++i) {
            Temp.x = HeartSpawner.position.x + (40 * i);
            Temp.y = HeartSpawner.position.y;
            Hearts[i] = Instantiate(Heart, Temp, Quaternion.identity, canvas.transform);
        }


        EnemyHealth = FindObjectOfType<Enemy>().GetHP();
        EnemyHeartNum = FindObjectOfType<Enemy>().GetHP() - 1;

        for (int i = 0; i < EnemyHealth; ++i) {
            Temp.x = EnemyHeartSpawner.position.x + (-40 * i);
            Temp.y = EnemyHeartSpawner.position.y;
            EnemyHearts[i] = Instantiate(Heart, Temp, Quaternion.identity, canvas.transform);
        }
    }

    void UpdateHearts() {
        PlayerHealth = FindObjectOfType<Paddle>().GetHP();

        if (PlayerHealth == 0) {
            FindObjectOfType<Paddle>().SetHP(5);
            FindObjectOfType<Enemy>().SetHP(5);
            MakeHearts();
        }
        else if (PlayerHealth - 1 < PlayerHeartNum) {
            Destroy(Hearts[PlayerHeartNum].gameObject);
            PlayerHeartNum--;
        }

        EnemyHealth = FindObjectOfType<Enemy>().GetHP();

        Debug.Log(EnemyHealth);
        Debug.Log(EnemyHeartNum);

        if (EnemyHealth == 0) {
            FindObjectOfType<Paddle>().SetHP(5);
            FindObjectOfType<Enemy>().SetHP(5);
            MakeHearts();
        }
        else if (EnemyHealth - 1 < EnemyHeartNum) {
            Destroy(EnemyHearts[EnemyHeartNum].gameObject);
            EnemyHeartNum--;
        }
    }
}