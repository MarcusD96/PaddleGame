using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {
    private int HP { get; set; } = 2;

    private void OnTriggerEnter2D(Collider2D collision) {
        switch(collision.gameObject.tag) {
            case "Paddle":  //shockwave hits paddle
                collision.gameObject.GetComponent<Paddle>().TakeHit(1);
                Destroy(gameObject);
                break;
            case "Projectile":
                Destroy(collision.gameObject);
                HP -= 1;
                if(HP < 1) {
                    Destroy(gameObject);
                }
                break;

            case "BallSideBad":
                Destroy(transform.parent.gameObject);
                break;

            default:
                break;
        }
    }
}
