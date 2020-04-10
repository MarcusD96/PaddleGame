using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleManager : GameManager {

    public Paddle player;
    public Zombie zombie;
    public Lobster lobster;

    public Transform playerSpawn, enemySpawn;

    public TextMeshProUGUI clicktostart;

    private bool Started;

    private void Startup() {
        Started = true;

        //4 = zombie, 5 = lobster
        int cs = SceneManager.GetActiveScene().buildIndex;

        player = Instantiate(player, playerSpawn.position, Quaternion.identity);

        switch (cs) {
            case 4:
                zombie = Instantiate(zombie, enemySpawn.position, Quaternion.identity);
                break;
            case 5:
                lobster = Instantiate(lobster, enemySpawn.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    private void LateUpdate() {
        if (!Started) {
            if (Input.GetMouseButtonDown(0)) {
                Startup();
                clicktostart.gameObject.SetActive(false);
            }
        }
        if (Started) {
            if (zombie || lobster) {
                CheckEnemyHP();
            }
            if (player) {
                CheckPlayerHP();
            }
        }
    }

    private void CheckEnemyHP() {
        if (zombie.GetHP() <= 0) {
            Destroy(GameState.zombies[GameState.CurrID]);
            FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.rewards);
        }
        else if (lobster.GetHP() <= 0) {
            FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.rewards);
        }
    }

    private void CheckPlayerHP() {
        if (player.GetComponent<Paddle>().GetHP() <= 0) {
            GameState.FirstStart = true;
            foreach(var z in GameState.zombies) {
                Destroy(z);
            }
            FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.overworld);
        }
    }
}
