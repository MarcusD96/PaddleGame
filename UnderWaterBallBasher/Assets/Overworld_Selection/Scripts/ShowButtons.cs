using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShowButtons : MonoBehaviour {
    public TextMeshProUGUI noWep;
    public List<Button> buttons = new List<Button>(3); //0 - top, 1 - middle, 2 - bottom

    string wep0, wep1, wep2;

    private void Awake() {
        if(GameState.earnedRewards.Count > 0) {
            wep0 = GameState.earnedRewards[0].name;
        }
        if(GameState.earnedRewards.Count > 1) {
            wep1 = GameState.earnedRewards[1].name;
        }
        if(GameState.earnedRewards.Count > 2) {
            wep2 = GameState.earnedRewards[2].name; 
        }

        switch(GameState.earnedRewards.Count) {
            case 0:
                noWep.gameObject.SetActive(true);
                break;

            case 1:
                buttons[0].gameObject.SetActive(true);
                buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = wep0;
                break;

            case 2:
                buttons[0].gameObject.SetActive(true);
                buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = wep0;

                buttons[1].gameObject.SetActive(true);
                buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = wep1;
                break;

            case 3:
                buttons[0].gameObject.SetActive(true);
                buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = wep0;

                buttons[1].gameObject.SetActive(true);
                buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = wep1;

                buttons[2].gameObject.SetActive(true);
                buttons[2].GetComponentInChildren<TextMeshProUGUI>().text = wep2;
                break;
        }
    }
}
