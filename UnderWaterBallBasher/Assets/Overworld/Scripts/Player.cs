using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Finish")) {
            FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.lobster);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Encounter")) {
            FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.zombie);
        }
    }
}
