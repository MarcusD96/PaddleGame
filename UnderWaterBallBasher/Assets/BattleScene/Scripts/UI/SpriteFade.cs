using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour {
    public SpriteRenderer NML;

    private IEnumerator FadeTo(float aValue, float aTime) {
        float alpha = NML.color.a;
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
            Color newColor = new Color(NML.color.r, NML.color.g, NML.color.b, Mathf.Lerp(alpha, aValue, t));
            NML.color = newColor;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("NML")) {
            StartCoroutine(FadeTo(0.3f, 2.0f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("NML")) {
            StartCoroutine(FadeTo(0.0f, 2.0f));
        }
    }
}
