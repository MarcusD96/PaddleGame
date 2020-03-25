﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : GameManager {

    public Paddle player;
    public Zombie zombie;
    public Lobster lobster;

    public Transform playerSpawn, enemySpawn;

    private bool Started;

    private void Startup() {
        Started = true;

        //2 = zombie, 3 = lobster
        int cs = SceneManager.GetActiveScene().buildIndex;

        player = Instantiate(player, playerSpawn.position, Quaternion.identity);

        switch (cs) {
            case 2:
                zombie = Instantiate(zombie, enemySpawn.position, Quaternion.identity);
                break;
            case 3:
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
            Destroy(OverworldState.zombies[OverworldState.CurrID]);
            FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.overworld);
        }
        else if (lobster.GetHP() <= 0) {
            FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.main);
        }
    }

    private void CheckPlayerHP() {
        if (player.GetComponent<Paddle>().GetHP() <= 0) {
            OverworldState.FirstStart = true;
            FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.main);
        }
    }
}
