using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour {
    public TextMeshProUGUI agg, spec, speed, points;
    public Image shield, time, boost;
    public Animator animator;

    // Update is called once per frame
    private void Awake() {
        agg.text = GameState.GetStat((int)Stats.agressiveness).ToString();
        spec.text = GameState.GetStat((int)Stats.special).ToString();
        speed.text = GameState.GetStat((int)Stats.speed).ToString();
        points.text = "Points: " + GameState.Points.ToString();

        if(GameState.HasShield) {
            shield.gameObject.SetActive(true);
        }
        if(GameState.HasSlow) {
            time.gameObject.SetActive(true);
        }
        if(GameState.HasBoost) {
            boost.gameObject.SetActive(true);
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(!animator.GetBool("Enabled")) { //not enabled
                animator.SetBool("Enabled", true);
            } else {
                animator.SetBool("Enabled", false);
            }
        }
    }
}
