﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomReward : MonoBehaviour {

    public GameObject button;
    private SpriteRenderer sr;
    public TextMeshProUGUI text;
    public List<Sprite> specialRewards = new List<Sprite>();

    private void Start() {
        button.SetActive(false);
        text.text = "";
        sr = GetComponent<SpriteRenderer>();
        if(GameState.FirstReward) {
            GameState.availableRewards = specialRewards;
            GameState.FirstReward = false;
        }
        StartCoroutine(SpinRewards());
    }

    IEnumerator SpinRewards() {
        yield return new WaitForSeconds(1.0f);
        var rewards = GameState.availableRewards; //temp
        var endTime = Time.time + 3.0f; //how long the rolling will last
        int rewardIndex = Random.Range(0, rewards.Count); //produce first pick

        do {
            rewardIndex++;
            if(rewardIndex >= rewards.Count) { //restart index
                rewardIndex = 0;
            }
            sr.sprite = rewards[rewardIndex]; //set the sprite
            yield return new WaitForSeconds(0.05f);
        } while(Time.time < endTime);

        text.text = sr.sprite.name.ToLower();
        text.gameObject.SetActive(true);

        var tmp = sr.sprite;
        //blink
        for(int j = 0; j < 3; j++) {
            sr.sprite = null;
            yield return new WaitForSeconds(0.2f);
            sr.sprite = tmp;
            yield return new WaitForSeconds(0.5f);
        }
        button.SetActive(true);

        switch(text.text) {
            case "special_shield":
                GameState.HasShield = true;
                GameState.earnedRewards.Add(sr.sprite);
                FindObjectOfType<SoundManager>().Play("Pickup_Shield");
                GameState.availableRewards.RemoveAt(rewardIndex); //delete from available rewards
                break;
            case "special_time":
                GameState.HasSlow = true;
                GameState.earnedRewards.Add(sr.sprite);
                FindObjectOfType<SoundManager>().Play("Pickup_Time");
                GameState.availableRewards.RemoveAt(rewardIndex); //delete from available rewards
                break;
            case "special_boost":
                GameState.HasBoost = true;
                GameState.earnedRewards.Add(sr.sprite);
                FindObjectOfType<SoundManager>().Play("Pickup_Boost");
                GameState.availableRewards.RemoveAt(rewardIndex); //delete from available rewards
                break;
            case "upgrade_agressiveness":
                GameState.SetStat((int)Stats.agressiveness, 2);
                break;
            case "upgrade_speed":
                GameState.SetStat((int)Stats.speed, 100);
                break;
            case "upgrade_special":
                GameState.SetStat((int)Stats.special, 2);
                break;
            default:
                break;
        }
    }

}
