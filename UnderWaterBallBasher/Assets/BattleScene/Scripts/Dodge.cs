using System.Collections;
using UnityEngine;

public class Dodge : MonoBehaviour {
    private bool start = false;

    // Update is called once per frame
    void Update() {
        if(!start) {
            StartCoroutine(Boost());
        }
    }

    IEnumerator Boost() {
        start = true;
        float startSpeed = FindObjectOfType<Paddle>().GetMoveSpeed();
        FindObjectOfType<Paddle>().SetMoveSpeed(startSpeed * 5.0f);
        yield return new WaitForSeconds(0.2f);
        FindObjectOfType<Paddle>().SetMoveSpeed(startSpeed);
        start = false;
    }
}
