using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldChild : MonoBehaviour {  

    private void Update() {
        var ball = FindObjectOfType<PlayerBall>();
        if(ball) {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), ball.GetComponent<Collider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Rock")) {
            Destroy(collision.gameObject);
            transform.parent.gameObject.GetComponent<Shield>().stopTime -= 0.5f;
        }
    }
}
