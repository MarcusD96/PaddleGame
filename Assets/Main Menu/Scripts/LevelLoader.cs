using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelLoader : MonoBehaviour {

    public Animator transition;
    public float transtionTime = 1.0f;

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            LoadNextLevel();
        }
    }

    void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        //Play anim
        transition.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(transtionTime);

        //load scene
        SceneManager.LoadScene(levelIndex);
    }
}
