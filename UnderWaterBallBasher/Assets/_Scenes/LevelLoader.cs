using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Levels {
    main,
    overworld,
    selection,
    zombie,
    lobster
}

public class LevelLoader : MonoBehaviour {

    public Animator transition;
    public float transtionTime = 1.0f;

    public void LoadNextLevel(Levels levels) { 
        StartCoroutine(LoadLevel((int)levels));
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
