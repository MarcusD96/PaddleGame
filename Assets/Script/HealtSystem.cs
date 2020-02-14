using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealtSystem : MonoBehaviour {

    public Canvas canvas;
    public Transform Heart;
    Transform[] Hearts;
    Transform[] EnemyHearts;

    public Transform HeartSpawner;
    private int PlayerHealth;
    private int PlayerHeartNum;

    public Transform EnemyHeartSpawner;
    private int EnemyHealth;
    private int EnemyHeartNum;

    /* Start is called before the first frame update*/
    void Start() {
        Hearts = new Transform[FindObjectOfType<Paddle>().hp];
        EnemyHearts = new Transform[FindObjectOfType<Enemy>().hp];

        MakeHearts();
    }

    /* Update is called once per frame*/
    void Update() {
        UpdateHearts();
    }

    void MakeHearts() {
        Debug.Log("Make Hearts");
        Vector2 Temp;

        PlayerHealth = FindObjectOfType<Paddle>().hp;
        PlayerHeartNum = FindObjectOfType<Paddle>().hp - 1;

        for (int i = 0; i < PlayerHealth; ++i) {
            Temp.x = HeartSpawner.position.x + (40 * i);
            Temp.y = HeartSpawner.position.y;
            Hearts[i] = Instantiate(Heart, Temp, Quaternion.identity, canvas.transform);
        }


        EnemyHealth = FindObjectOfType<Enemy>().hp;
        EnemyHeartNum = FindObjectOfType<Enemy>().hp - 1;

        for (int i = 0; i < EnemyHealth; ++i) {
            Temp.x = EnemyHeartSpawner.position.x + (-40 * i);
            Temp.y = EnemyHeartSpawner.position.y;
            EnemyHearts[i] = Instantiate(Heart, Temp, Quaternion.identity, canvas.transform);
        }
    }

    void UpdateHearts() {
        PlayerHealth = FindObjectOfType<Paddle>().hp;

        if (PlayerHealth == 0) {
            FindObjectOfType<Paddle>().hp = 5;
            FindObjectOfType<Enemy>().hp = 5;
            MakeHearts();
        }
        else if (PlayerHealth - 1 < PlayerHeartNum) {
            Destroy(Hearts[PlayerHeartNum].gameObject);
            PlayerHeartNum--;
        }

        EnemyHealth = FindObjectOfType<Enemy>().hp;

        Debug.Log(EnemyHealth);
        Debug.Log(EnemyHeartNum);

        if (EnemyHealth == 0) {
            FindObjectOfType<Paddle>().hp = 5;
            FindObjectOfType<Enemy>().hp = 5;
            MakeHearts();
        }
        else if (EnemyHealth - 1 < EnemyHeartNum) {
            Destroy(EnemyHearts[EnemyHeartNum].gameObject);
            EnemyHeartNum--;
        }
    }
}
