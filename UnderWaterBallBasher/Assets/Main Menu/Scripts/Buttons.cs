using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour {
    //Button back; //used when bringing up settings and lowering it
    private GameObject buttons; //"          "
    private Image settings, reset; //refers to the settings background
    private SoundManager sound;

    void Awake() {
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
                settings = i; //find the group of settings items to set inactive/active later on
            }
            if(i.CompareTag("Reset")) {
                reset = i; //find the group of settings items to set inactive/active later on
            }
            if(settings != null && reset != null) {
                break;
            }
        }
        sound = FindObjectOfType<SoundManager>();
    }

    public void OnStart() {
        FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.overworld); //load the main battle scene
        sound.Play("Click");
    }

    public void OnSettingsStart() {
        buttons.gameObject.SetActive(false); //make the buttons and title invisible when going into settings
        settings.gameObject.SetActive(true); //makes settings popup visible
        sound.Play("Click");
    }

    public void OnSettingsStop() {
        settings.gameObject.SetActive(false); //makes settings popup invisible
        buttons.SetActive(true); //make the buttons and title visible when coming out of settings
        sound.Play("Click");
    }

    public void OnResetStart() {
        buttons.gameObject.SetActive(false); //make the buttons and title invisible when going into settings
        reset.gameObject.SetActive(true); //makes settings popup visible
        sound.Play("Click");
    }

    public void OnResetStop() {
        reset.gameObject.SetActive(false); //makes rest popup invisible
        buttons.SetActive(true); //make the buttons and title visible when coming out of settings
        sound.Play("Click");
    }

    public void OnExit() {
        //if played in unity vs played in its own application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void ResetStats() {
        sound.Play("Click");
        OnResetStop();
        GameState.DefaultStats();
    }

    public void Next() {
        sound.Play("Click");
        FindObjectOfType<LevelLoader>().LoadNextLevel((Levels)GameState.NextLevel);
    }

    public void NextToOverworld() {
        sound.Play("Click");
        FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.overworld);
    }

    public void NextToMainMenu() {
        sound.Play("Click");
        FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.main);
        Time.timeScale = 1;
    }

    public void SetWeapon() {
        string tmp = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        switch(tmp.ToLower()) {
            case "special_shield":
                sound.Play("Pickup_Shield");
                GameState.EquippedWeapon = 0;
                break;

            case "special_time":
                sound.Play("Pickup_Time");
                GameState.EquippedWeapon = 1;
                break;

            case "special_dodge":
                sound.Play("Pickup_Boost");
                GameState.EquippedWeapon = 2;
                break;

            default:
                break;
        }
        FindObjectOfType<SoundManager>().Play("Click");
        FindObjectOfType<LevelLoader>().LoadNextLevel((Levels)GameState.NextLevel);
    }
}
