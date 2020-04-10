using System.Collections;
using TMPro;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {
    private float startTime, stopTime = 5.0f;
    private bool start = false;
    public TextMeshProUGUI text;

    private void Start() {
        startTime = Time.timeSinceLevelLoad;
        foreach(var t in Resources.FindObjectsOfTypeAll<TextMeshProUGUI>()) {
            if(t.CompareTag("SpecialCountdown")) {
                t.gameObject.SetActive(true);
                text = t;
                break;
            }
        }
        text.text = Mathf.Ceil(stopTime).ToString();
    }

    // Update is called once per frame
    void Update() {
        if(!start) {
            StartCoroutine(Boost());
        }
        text.text = Mathf.FloorToInt((startTime + stopTime) - Time.timeSinceLevelLoad).ToString();
    }

    IEnumerator Boost() {
        start = true;
        var paddle = FindObjectOfType<Paddle>();
        paddle.SetMoveSpeed(paddle.GetMoveSpeed() * 5.0f);
        yield return new WaitForSeconds(stopTime);
        paddle.SetMoveSpeed(paddle.GetMoveSpeed() / 5.0f);
        text.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
