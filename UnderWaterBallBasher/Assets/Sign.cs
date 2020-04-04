using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour {
    public TextMeshProUGUI text;
    public GameObject msg;
    private bool on = false;

    private void Update() {
        if(on) {
            if(Input.GetKeyDown(KeyCode.F)) {
                if(!msg.activeInHierarchy) {
                    text.gameObject.SetActive(false);

                    switch(name.ToLower()) {
                        case "wasd":
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "Press W to go UP.\nPress A to go LEFT.\nPress S to go Down.\nPress D to go right.";
                            break;

                        case "enemies":
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "Run into this enemy over here to initate a battle.";
                            break;

                        case "statsmenu":
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "Pressing E will bring down yours stats and special inventory.";
                            break;

                        case "tip":
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "You can select only 1 special attack to bring into battle with you...choose wisely, each has their advantages and disadvantages.";
                            break;

                        default:
                            break;
                    }

                    msg.SetActive(true);
                }
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        text.gameObject.SetActive(true);
        on = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(text.gameObject.activeInHierarchy) {
            text.gameObject.SetActive(false);
        }
        if(msg.activeInHierarchy) {
            msg.SetActive(false);
        }
        on = false;
    }
}
