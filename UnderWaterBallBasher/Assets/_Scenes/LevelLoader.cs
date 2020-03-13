using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public Animator transition;
    public float transtionTime = 1.0f;
    bool nextLevel = false;

    // Update is called once per frame
    void Update() {
        if(nextLevel) {
            LoadNextLevel();
        }
    }

    void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void SetNextLevel() {
        nextLevel = true;
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
