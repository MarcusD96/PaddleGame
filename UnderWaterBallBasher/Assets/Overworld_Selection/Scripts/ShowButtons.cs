using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ShowButtons : MonoBehaviour {
    public TextMeshProUGUI noWep;
    public List<Transform> spaces = new List<Transform>(); //0 - left, 1 - middle, 2 - right

    private void Awake() {
        switch(GameState.earnedRewards.Count) {
            case 0:
                noWep.gameObject.SetActive(true);
                break;

            case 1:
                Instantiate(GameState.earnedRewards[0], spaces[1]);
                break;

            case 2:
                Instantiate(GameState.earnedRewards[0], spaces[0]);
                Instantiate(GameState.earnedRewards[1], spaces[2]);
                break;

            case 3:
                Instantiate(GameState.earnedRewards[0], spaces[0]);
                Instantiate(GameState.earnedRewards[1], spaces[1]);
                Instantiate(GameState.earnedRewards[2], spaces[2]);
                break;
        }
    }
}
