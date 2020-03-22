using System.Collections.Generic;
using UnityEngine;

public class OverworldManager : GameManager {

    public GameObject player, enemy, boss;
    public List<Transform> enemyLocs =  new List<Transform>(5);
    public Transform playerSpawn;

    private void Awake() {
        print(OverworldState.FirstStart);
        if(OverworldState.FirstStart) { //if its the first time running, set everything up
            player = Instantiate(player, playerSpawn.position, Quaternion.identity);
            OverworldState.FirstStart = false;
            
            for(int i = 0; i < enemyLocs.Capacity; i++) {  //populate the initial zombie list
                if(i != enemyLocs.Capacity - 1) { //if its not the last one, spawn the zombies - add them to the list of zombies to save
                    OverworldState.zombies.Add(Instantiate(enemy, enemyLocs[i].position, Quaternion.identity));
                } else { //spawn the boss - dont need to save as if boss is killed, then level is complete
                    Instantiate(boss, enemyLocs[i].position, Quaternion.identity);
                }
            }
        } else {
            player = Instantiate(player, OverworldState.PlayerPos, Quaternion.identity);
        }
        player.name = "Player";
    }
    private void Update() {
        OverworldState.PlayerPos = player.transform.position;
    }
}
