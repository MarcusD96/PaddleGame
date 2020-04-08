using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject PauseUI;
    public GameObject SettingsUI;
    //public GameObject WinUI;

    public Slider Effects;
    public Slider Music;

    public AudioMixer audioMixer;
    public AudioMixer audioMixerMusic;

    private void Start() {
        SetVolume(PlayerPrefs.GetFloat("Effects"));
        SetVolumeMusic(PlayerPrefs.GetFloat("Music"));

        Effects.value = PlayerPrefs.GetFloat("Effects");
        Music.value = PlayerPrefs.GetFloat("Music");

        PlayerPrefs.SetInt("MaxKills", PlayerPrefs.GetInt("MaxKills") + 2);
        PlayerPrefs.SetInt("Kills", PlayerPrefs.GetInt("MaxKills"));


        PauseUI.SetActive(false);
        SettingsUI.SetActive(false);
        //WinUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;

    }
    private void Update() {
        //if (PlayerPrefs.GetInt("Kills") <= 0)
        //{
        //    Win();
        //    PlayerPrefs.SetInt("Kills", -1);
        //}

        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(IsPaused) {
                Pause();
                Resume();
            } else if(!IsPaused) {
                Pause();
            }
        }
    }

    public void Resume() {
        PauseUI.SetActive(false);
        SettingsUI.SetActive(false);
        //WinUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Pause() {
        PauseUI.SetActive(true);
        SettingsUI.SetActive(false);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    //public void Win()
    //{
    //    WinUI.SetActive(true);
    //    Time.timeScale = 0f;
    //    IsPaused = true;
    //}

    public void Settings() {
        PauseUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void SetVolume(float volume) {
        //audioMixer.SetFloat("volume", volume);
        //PlayerPrefs.SetFloat("Effects", volume);
        foreach(var s in FindObjectOfType<SoundManager>().sounds) {
            s.volume = volume;
        }
    }

    public void SetVolumeMusic(float volumeMusic) {
        //audioMixerMusic.SetFloat("volumeMusic", volumeMusic);

        //PlayerPrefs.SetFloat("Music", volumeMusic);
    }

    public void SetQuality(int quality) {
        QualitySettings.SetQualityLevel(quality);
    }
}
