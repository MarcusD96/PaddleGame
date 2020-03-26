using System.Collections.Generic;
using UnityEngine;

public class OverworldManager : GameManager {

    public GameObject player, enemy, boss;
    public List<Transform> enemyLocs =  new List<Transform>(5);
    public Transform playerSpawn;

    private void Awake() {
        if(GameState.FirstStart) { //if its the first time running, set everything up
            player = Instantiate(player, playerSpawn.position, Quaternion.identity);
            GameState.FirstStart = false;
            
            for(int i = 0; i < enemyLocs.Capacity; i++) {  //populate the initial zombie list
                if(i != enemyLocs.Capacity - 1) { //if its not the last one, spawn the zombies - add them to the list of zombies to save
                    GameObject tmp = Instantiate(enemy, enemyLocs[i].position, Quaternion.identity);                    
                    DontDestroyOnLoad(tmp); //dont kill the enemy when loading a new scene
                    GameState.zombies.Add(tmp);
                    tmp.GetComponent<ZombieId>().ID = i;
                    
                } else { //spawn the boss, save to list
                    GameObject tmp = Instantiate(boss, enemyLocs[i].position, Quaternion.identity);
                    DontDestroyOnLoad(tmp); //dont kill the boss when loading a new scene
                }
            }
        } else {
            player = Instantiate(player, GameState.PlayerPos, Quaternion.identity);
        }
        player.name = "Player";
    }
    private void Update() {
        GameState.PlayerPos = player.transform.position;
    }
}
