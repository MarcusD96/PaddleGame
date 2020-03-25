using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {
    private SpriteRenderer playerBounds;
    private Vector2 screenBounds;
    private float objectWidth, objectHeight; 
    public float xOffsetL, xOffsetR, yOffset;

    private void Start() {
        foreach(var s in FindObjectsOfType<SpriteRenderer>()) {
            if(s.CompareTag("PlayerArea")) {
                playerBounds = s;
                break;
            }
        }
    }

    // Update is called once per frame
    private void LateUpdate () {
        screenBounds = new Vector2(playerBounds.bounds.extents.x, playerBounds.bounds.extents.y - yOffset);
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth - xOffsetL, screenBounds.x - objectWidth - xOffsetR);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
