using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {
    private bool start = false;

    // Update is called once per frame
    void Update() {
        if(!start) {
            StartCoroutine(Boost());
        }
    }

    IEnumerator Boost() {
        start = true;
        var paddle = FindObjectOfType<Paddle>();
        paddle.SetMoveSpeed(paddle.GetMoveSpeed() * 5.0f);
        yield return new WaitForSeconds(5.0f);
        paddle.SetMoveSpeed(paddle.GetMoveSpeed() / 5.0f);
        start = false;
    }
}
