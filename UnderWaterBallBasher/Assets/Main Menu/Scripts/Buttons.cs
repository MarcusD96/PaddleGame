﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour {
    //Button back; //used when bringing up settings and lowering it
    private GameObject buttons; //"          "
    private Image settings, reset; //refers to the settings background

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
    }

    public void OnStart() {
        FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.overworld); //load the main battle scene
    }

    public void OnSettingsStart() {
        buttons.gameObject.SetActive(false); //make the buttons and title invisible when going into settings
        settings.gameObject.SetActive(true); //makes settings popup visible
    }

    public void OnSettingsStop() {
        settings.gameObject.SetActive(false); //makes settings popup invisible
        buttons.SetActive(true); //make the buttons and title visible when coming out of settings
    }

    public void OnResetStart() {
        buttons.gameObject.SetActive(false); //make the buttons and title invisible when going into settings
        reset.gameObject.SetActive(true); //makes settings popup visible
    }

    public void OnResetStop() {
        reset.gameObject.SetActive(false); //makes rest popup invisible
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

    public void ResetStats() {
        OnResetStop();
        GameState.DefaultStats();
    }

    public void Next() {
        FindObjectOfType<LevelLoader>().LoadNextLevel((Levels)GameState.NextLevel);
    }

    public void NextToOverworld() {
        FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.overworld);
    }

    public void NextToMainMenu() {
        FindObjectOfType<LevelLoader>().LoadNextLevel(Levels.main);
        Time.timeScale = 1;
    }

    public void SetWeapon() {
        string tmp = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        switch(tmp.ToLower()) {
            case "special_shield":
                GameState.EquippedWeapon = 0;
                break;

            case "special_time":
                GameState.EquippedWeapon = 1;
                break;

            case "special_dodge":
                GameState.EquippedWeapon = 2;
                break;

            default:
                break;
        }
        FindObjectOfType<LevelLoader>().LoadNextLevel((Levels)GameState.NextLevel);
    }
}
