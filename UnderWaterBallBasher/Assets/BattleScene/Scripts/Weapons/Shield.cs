using UnityEngine;
using TMPro;

public class Shield : MonoBehaviour {
    private float startTime;
    public float stopTime;
    private TextMeshProUGUI text;

    private void Start() {
        startTime = Time.timeSinceLevelLoad;
        stopTime = 10.0f;

        foreach(var t in Resources.FindObjectsOfTypeAll<TextMeshProUGUI>()) {
            if(t.CompareTag("SpecialCountdown")) {
                t.gameObject.SetActive(true);
                text = t;
                break;
            }
        }
        text.text = Mathf.Ceil(stopTime).ToString();
    }

    private void Update() {
        text.text = Mathf.FloorToInt((startTime + stopTime) - Time.timeSinceLevelLoad).ToString();

        transform.position = FindObjectOfType<Paddle>().transform.position;

        if (Time.timeSinceLevelLoad >= stopTime + startTime) { //5 or more seconds has past
            text.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}