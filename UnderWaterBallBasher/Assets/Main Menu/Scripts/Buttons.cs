using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
    //Button back; //used when bringing up settings and lowering it
    GameObject buttons; //"          "
    Image img; //refers to the settings background

    void Start() {
        foreach(var i in Resources.FindObjectsOfTypeAll<GameObject>()) {
            switch(i.tag) {
                case "Buttons":
                    buttons = i; //find the group of main menu items to use later on
                    break;
                default:
                    break;
            }
        }
        foreach(var i in Resources.FindObjectsOfTypeAll<Image>()) {
            if(i.CompareTag("Settings")) { 
                img = i; //find the group of settings items to set inactive/active later on
                break;
            }
        }
    }

    public void OnStart() {
        FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.overworld); //load the main battle scene
    }

    public void OnSettingsStart() {
        buttons.gameObject.SetActive(false); //make the buttons and title invisible when going into settings
        img.gameObject.SetActive(true); //makes settings popup visible
    }

    public void OnSettingsStop() {
        img.gameObject.SetActive(false); //makes settings popup invisible
        buttons.SetActive(true); //make the buttons and title visible when coming out of settings
    }

    public void OnExit() {
        //if played in unity vs played in its own application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void Next() {
        FindObjectOfType<LevelLoader>().LoadNextLevel((Levels)GameState.NextLevel);
    }
    
    public void NextToOverworld() {
        FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.overworld);
    }

    public void SetShield() {
        GameState.EquippedWeapon = 1;
        FindObjectOfType<LevelLoader>().LoadNextLevel((Levels)GameState.NextLevel);
    }

    public void SetTimeSlow() {
        GameState.EquippedWeapon = 2;
        FindObjectOfType<LevelLoader>().LoadNextLevel((Levels)GameState.NextLevel);
    }
}
