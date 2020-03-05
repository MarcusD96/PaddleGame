using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArm : MonoBehaviour {
    private GameObject paddle;
    public GameObject arm, shoulder;
    public List<GameObject> arms;

    private Vector3 paddlePos;

    private float extendRetractSpeed = 0.05f;
    private bool shooting = false;
    public bool canShoot = false;

    // Start is called before the first frame update
    void Start() {
        paddle = FindObjectOfType<Paddle>().gameObject;
        paddlePos = paddle.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(canShoot) {
            if(!shooting) {
                paddlePos = paddle.transform.position;
                StartCoroutine(SpawnArms());
            }
        }
    }

    public IEnumerator SpawnArms() {
        canShoot = false;
        shooting = true;
        int i = -1;
        float paddleX = paddle.transform.position.x;

        do {
            //paddlePos = paddle.transform.position; uncomment this to follow the paddle slightly
            Vector3 pos = transform.position; //to keep things still when the enemy is in movement
            if(i < 0) {
                arms.Add(Instantiate(arm, shoulder.transform.position, AngleToPaddle(paddlePos, pos)));
                i++;
            } else {
                arms.Add(Instantiate(arm, arms[i].GetComponent<GetChildInfo>().GetEndPos(), AngleToPaddle(paddlePos, pos)));
                i++;
            }

            if(i > 30) { //fail-safe
                break;
            }
            yield return new WaitForSeconds(extendRetractSpeed);
        } while(arms[i].transform.position.x > paddleX);

        yield return new WaitForSeconds(1.5f);
        arms.Reverse();
        int count = arms.Count - 1;
        for(int n = 0; n < arms.Count; n++) {
            Destroy(arms[n]);
            yield return new WaitForSeconds(extendRetractSpeed);
        }
        arms.Clear();
        shooting = false;
    }

    private Quaternion AngleToPaddle(Vector3 paddlePos_, Vector3 pos) {
        Vector3 delta = pos - paddlePos_;
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        return rotation;
    }
}
