using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {

    private TextMeshProUGUI text;

    private void Start() {
        text = FindObjectOfType<TextMeshProUGUI>();
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Finish")) {
            if(OverworldState.AllZombies()) {
                FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.lobster);
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
            OverworldState.CurrID = collision.gameObject.GetComponent<ZombieId>().ID;
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, -1);
            FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.zombie);
        }
    }

    IEnumerator NoFight() {
        text.gameObject.SetActive(true); //start

        yield return new WaitForSeconds(1); //stay on screen

        text.gameObject.SetActive(false); //finish
    }
}
