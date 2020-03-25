using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldChild : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Rock")) {
            Destroy(collision.gameObject);
            transform.parent.gameObject.GetComponent<Shield>().stopTime -= 0.5f;
        }
    }
}
