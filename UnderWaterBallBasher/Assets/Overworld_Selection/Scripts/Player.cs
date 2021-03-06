﻿using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {

    private TextMeshProUGUI text;

    private void Start() {
        foreach(var t in Resources.FindObjectsOfTypeAll<TextMeshProUGUI>()) {
            if(t.CompareTag("Notice")) {
                text = t;
                t.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Finish")) {
            if(GameState.AllZombies()) {
                GameState.NextLevel = (int)Levels.lobster;
                FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.selection);
            } else {
                if(!text.IsActive()) {
                    StartCoroutine(NoFight()); 
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        StopCoroutine(NoFight());
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Encounter")) {
            GameState.NextLevel = (int)Levels.zombie;
            GameState.CurrID = collision.gameObject.GetComponent<ZombieId>().ID;
            FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.selection);
        }
    }

    IEnumerator NoFight() {
        text.gameObject.SetActive(true); //start

        yield return new WaitForSeconds(1); //stay on screen

        text.gameObject.SetActive(false); //finish
    }
}
