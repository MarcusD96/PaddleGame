using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player, enemy, ball;
    public Transform playerSpawn, enemySpawn, ballSpawn;

    private void Start () {
        //Instantiate(player, playerSpawn.transform.position, Quaternion.identity);
        Instantiate(enemy, enemySpawn.transform.position, Quaternion.identity);
        Instantiate(ball, ballSpawn.transform.position, Quaternion.identity);
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
}
