using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player, enemy;
    public Transform playerSpawn, enemySpawn;

    private void Awake () {
        Instantiate(player, playerSpawn.position, Quaternion.identity);

        if(enemy) {
            Instantiate(enemy, enemySpawn.position, Quaternion.identity); 
        }
    }

    private void LateUpdate () {
        //CheckEnemyHP();
        //CheckPlayerHP();
    }

    public static int Level;
    public static string KorP;

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

    private void CheckEnemyHP() {
        if (enemy.GetComponent<Lobster>().GetHP() <= 0) {
            MainMenu();
        }
    }

    private void CheckPlayerHP () {
        if(player.GetComponent<Paddle>().GetHP() <= 0) {
            MainMenu();
        }
    }
}
