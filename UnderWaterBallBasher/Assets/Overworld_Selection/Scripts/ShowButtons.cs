using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ShowButtons : MonoBehaviour {
    public TextMeshProUGUI noWep;
    public List<GameObject> choices = new List<GameObject>();

    private void Awake() {
        //0 both, 1 shield, 2 slow
        if(!GameState.HasShield) { //none
            if(!GameState.HasSlow) {
                noWep.gameObject.SetActive(true);
            }
        }

        if(GameState.HasShield) { //shield and slow
            if(GameState.HasSlow) {
                choices[0].SetActive(true);
            }
        }

        if(GameState.HasShield) { //shield only
            if(!GameState.HasSlow) {
                choices[1].SetActive(true);
            }
        }

        if(GameState.HasSlow) { //slow only
            if(!GameState.HasShield) {
                choices[2].SetActive(true);
            }
        }
    }
}
