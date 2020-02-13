using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player, enemy, ball;
    public Transform playerSpawn, enemySpawn, ballSpawn;

    private void Start () {
        player = FindObjectOfType<Paddle>().gameObject;
        Instantiate(enemy, enemySpawn.transform.position, Quaternion.identity);
        Instantiate(ball, ballSpawn.transform.position, Quaternion.identity);
    }

    void LateUpdate () {
        CheckEnemyHP();
        CheckPlayerHP();
    }

    public void CharSel () {
        SceneManager.LoadScene("CharSel");
    }

    public void QuitGame () {
        Application.Quit();
    }

    public void GameOver () {
        SceneManager.LoadScene("GameOver");
    }

    public void MainMenu () {
        SceneManager.LoadScene("Main");
    }

    public void Winner () {
        SceneManager.LoadScene("Winner");
    }

    //void CheckEnemyHP() {
    //    if (enemy.GetComponent<Enemy>().hp <= 0) {
    //        Destroy(enemy);
    //        MainMenu();
    //    }
    //}

    //void CheckPlayerHP () {
    //    if(player.GetComponent<Paddle>().hp <= 0) {
    //        Destroy(player);
    //        MainMenu();
    //    }
    //}
}
