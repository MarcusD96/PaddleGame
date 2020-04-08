using UnityEngine;
using TMPro;

public class TimeSlow : MonoBehaviour {
    private float slowdownFactor;
    private float slowdownLength;
    private float startTime;

    public TextMeshProUGUI text;

    private void Start() {
        slowdownFactor = 0.5f;
        slowdownLength = 6.0f;
        startTime = Time.unscaledTime;
        Time.timeScale = slowdownFactor;
        transform.position = Vector3.zero;

        foreach(var t in Resources.FindObjectsOfTypeAll<TextMeshProUGUI>()) {            
            if (t.CompareTag("SpecialCountdown")) {
                t.gameObject.SetActive(true);
                text = t;
                break;
            }
        }
        text.text = Mathf.Ceil(slowdownLength).ToString();
    }

    void Update() {
        //scale back up slowly
        //Time.timeScale += (1.0f / slowdownLength) * Time.unscaledDeltaTime;
        //Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1.0f);

        text.text = Mathf.FloorToInt((startTime + slowdownLength) - Time.unscaledTime).ToString();

        //reset scale back to 1 after slow length
        if (Time.unscaledTime > startTime + slowdownLength) {
            Time.timeScale = 1.0f;
            text.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
