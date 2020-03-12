using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChildInfo : MonoBehaviour {
    public GameObject end, body;

    public Vector3 GetEndPos() {
        return end.transform.position;
    }

    public void SetBodySprite(Sprite sp) {
        body.GetComponent<SpriteRenderer>().sprite = sp;
    }
}