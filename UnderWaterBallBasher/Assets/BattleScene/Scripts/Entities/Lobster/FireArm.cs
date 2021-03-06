﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArm : MonoBehaviour {
    private GameObject paddle;
    public GameObject arm, shoulder;
    public List<GameObject> arms;

    public Sprite claw, body;
    public Animator lobster;

    private Vector3 paddlePos;

    private readonly float extendRetractSpeed = 0.025f;
    private bool shooting = false;
    public bool canShoot = false;

    // Start is called before the first frame update
    private void Start() {
        canShoot = GetComponent<Lobster>().noMove;

        paddle = FindObjectOfType<Paddle>().gameObject;
        paddlePos = paddle.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if(!shooting) {
            if(canShoot) {
                paddlePos = paddle.transform.position;
                StartCoroutine(SpawnArms());
            }
        }
    }

    public IEnumerator SpawnArms() {
        shooting = true;
        int i = -1;
        float paddleX = paddle.transform.position.x;

        do {
            //paddlePos = paddle.transform.position; //uncomment this to follow the paddle slightly
            Vector3 pos = shoulder.transform.position; //to keep things still when the enemy is in movement
            if(i < 0) {
                arms.Add(Instantiate(arm, shoulder.transform.position, AngleToPaddle(paddlePos, pos)));
                i++;
                arms[i].GetComponent<GetChildInfo>().SetBodySprite(claw);
            } else {
                arms.Add(Instantiate(arm, arms[i].GetComponent<GetChildInfo>().GetEndPos(), AngleToPaddle(paddlePos, pos)));
                i++;
                arms[i - 1].GetComponent<GetChildInfo>().SetBodySprite(body);
                
                arms[i].GetComponent<GetChildInfo>().SetBodySprite(claw);

                lobster.SetBool("isExtending", true);
            }

            if(i > 50) { //fail-safe
                break;
            }
            arms[i].name = "Arm Segment"; //not 'clone'
            yield return new WaitForSeconds(extendRetractSpeed);
        } while(arms[i].transform.position.x > paddleX);
        

        yield return new WaitForSeconds(0.5f);
        arms.Reverse();
        int count = arms.Count - 1;
        for(int n = 0; n < arms.Count; n++) {
            Destroy(arms[n]);
            if(!(n == count)) {
                arms[n + 1].GetComponent<GetChildInfo>().SetBodySprite(claw);
            }
            yield return new WaitForSeconds(extendRetractSpeed);
        }
        lobster.SetBool("isExtending", false);

        arms.Clear();
        shooting = canShoot = false;
    }

    private Quaternion AngleToPaddle(Vector3 firePos, Vector3 pos) {
        Vector3 delta = pos - firePos;
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        return rotation;
    }
}
