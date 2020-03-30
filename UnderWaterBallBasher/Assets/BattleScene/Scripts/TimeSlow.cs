using UnityEngine;
using TMPro;

public class TimeSlow : MonoBehaviour {
    private float slowdownFactor;
    private float slowdownLength;
    private float startTime;

    //public TextMeshProUGUI text;

    private void Start() {
        slowdownFactor = 0.5f;
        slowdownLength = 5.0f;
        startTime = Time.time;
        Time.timeScale = slowdownFactor;
        transform.position = Vector3.zero;
    }

    void Update() {
        //scale back up slowly
        //Time.timeScale += (1.0f / slowdownLength) * Time.unscaledDeltaTime;
        //Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1.0f);

        //reset scale back to 1 after slow length
        if (Time.time > startTime + slowdownLength) {
            Time.timeScale = 1.0f;
            Destroy(gameObject);
        }
    }
}
