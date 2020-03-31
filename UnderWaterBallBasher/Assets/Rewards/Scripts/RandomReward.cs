using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomReward : MonoBehaviour {

    public SpriteRenderer sr;
    public List<Sprite> specialRewards = new List<Sprite>();

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        if(GameState.FirstReward) {
            GameState.availableRewards = specialRewards;
            GameState.FirstReward = false;
        }
        StartCoroutine(SpinRewards());
    }

    IEnumerator SpinRewards() {
        var rewards = GameState.availableRewards; //temp
        var endTime = Time.time + 3.0f; //how long the rolling will last
        int i = Random.Range(0, rewards.Count); //produce first pick

        do {
            i++;
            if(i >= rewards.Count) { //restart index
                i = 0;
            }
            sr.sprite = rewards[i]; //set the sprite
            yield return new WaitForSeconds(0.1f);
        } while(Time.time < endTime);

        GameState.availableRewards.RemoveAt(i); //delete from available rewards

        var tmp = sr.sprite;
        //blink
        for(i = 0; i < 3; i++) {
            sr.sprite = null;
            yield return new WaitForSeconds(0.2f);
            sr.sprite = tmp;
            yield return new WaitForSeconds(0.5f); 
        }

        switch(sr.sprite.name.ToLower()) {
            case "upgrade_shield":
                GameState.HasShield = true;
                break;
            case "upgrade_time":
                GameState.HasSlow = true;
                break;
            case "upgrade_dodge":
                GameState.HasDodge = true;
                break;
            case "upgrade_speed":
                GameState.HasSpeed = true;
                break;
            case "upgrade_cash":
                GameState.HasCash = true;
                break;
            case "upgrade_range":
                GameState.HasRange = true;
                break;
            default:
                break;
        }
    }

}
