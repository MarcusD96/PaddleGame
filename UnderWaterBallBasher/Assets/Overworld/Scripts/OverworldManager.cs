﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldManager : GameManager {

    public GameObject player, enemy;
    public Transform playerSpawn, enemySpawn;

    private void Awake () {
        Instantiate(player, playerSpawn.position, Quaternion.identity);

        if(enemy) {
            Instantiate(enemy, enemySpawn.position, Quaternion.identity); 
        }
    }
}
