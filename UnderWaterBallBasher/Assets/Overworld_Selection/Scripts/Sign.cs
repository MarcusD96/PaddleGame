using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour {
    public TextMeshProUGUI text;
    public GameObject msg;
    private bool on = false;

    private void Awake() {
        text.gameObject.SetActive(false);
        msg.SetActive(false);
    }

    private void Update() {
        if(on) { //trigged in ontrigger
            if(Input.GetKeyDown(KeyCode.F)) { //input key
                if(!msg.activeInHierarchy) { //it is not already up

                    msg.SetActive(true); //make it appear
                    text.gameObject.SetActive(false); //turn off instruction to press f

                    switch(name.ToLower()) { //find which sign we had collided into and make the corresponding text
                        case "wasd":
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "Press W to go UP.\nPress A to go LEFT.\nPress S to go Down.\nPress D to go right.";
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "Press W to go UP.\nPress A to go LEFT.\nPress S to go Down.\nPress D to go right.";
                            break;

                        case "enemies":
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "Run into this enemy over here to initate a battle.";
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "Run into this enemy over here to initate a battle.";
                            break;

                        case "statsmenu":
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "Pressing E will bring down yours stats and special inventory.";
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "Pressing E will bring down yours stats and special inventory.";
                            break;

                        case "tip":
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "You can select only 1 special attack to bring into battle with you...choose wisely, each has their advantages and disadvantages.";
                            msg.GetComponentInChildren<TextMeshProUGUI>().text = "You can select only 1 special attack to bring into battle with you...choose wisely, each has their advantages and disadvantages.";
                            break;

                        default:
                            break;
                    }
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
