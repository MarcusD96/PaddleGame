using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RandomReward : MonoBehaviour {

    public GameObject button;
    public SpriteRenderer sr;
    public List<Sprite> specialRewards = new List<Sprite>();

    private void Start() {
        button.SetActive(false);
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
            yield return new WaitForSeconds(0.1f);
        } while(Time.time < endTime);

        var tmp = sr.sprite;
        //blink
        for(int j = 0; j < 3; j++) {
            sr.sprite = null;
            yield return new WaitForSeconds(0.2f);
            sr.sprite = tmp;
            yield return new WaitForSeconds(0.5f); 
        }
        button.SetActive(true);

        switch(sr.sprite.name.ToLower()) {
            case "upgrade_shield":
                GameState.HasShield = true;
                GameState.availableRewards.RemoveAt(rewardIndex); //delete from available rewards
                break;
            case "upgrade_time":
                GameState.HasSlow = true;
                GameState.availableRewards.RemoveAt(rewardIndex); //delete from available rewards
                break;
            case "upgrade_dodge":
                GameState.HasDodge = true;
                GameState.availableRewards.RemoveAt(rewardIndex); //delete from available rewards
                break;
            case "upgrade_agressiveness":
                GameState.SetStat((int)Stats.agressiveness, 25);
                break;
            case "upgrade_speed":
                GameState.SetStat((int)Stats.speed, 25);
                break;
            case "upgrade_special":

                break;
            default:
                break;
        }
    }

}
