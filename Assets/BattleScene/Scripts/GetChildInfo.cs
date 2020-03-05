using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChildInfo : MonoBehaviour {
    public GameObject end;

    public Vector3 GetEndPos() {
        return end.transform.position;
    }
}