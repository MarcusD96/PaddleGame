﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour {

    public GameObject specAtk, noMansLand, topBorder, bottomBorder, leftBorder;
    Transform shootPos;

    Rigidbody2D rb;

<<<<<<< Updated upstream
    public float speed, hp = 1;
    private float moveValueZ;
=======
    public float speed, rotSpeed;
    public int hp = 5;
    float rotation = 0f, dt;
>>>>>>> Stashed changes

    Vector3 mousePosition_, direction;

    // Start is called before the first frame update
    void Start () {
        tag = "Paddle";
        name = "Paddle";

        rb = GetComponent<Rigidbody2D>();

        shootPos = GetComponentInChildren<Transform>();

        if(speed == 0) {
            speed = 20;
        }
    }

    // Update is called once per frame
    void Update () {
        moveValueZ = 0;
        Controls();

        //follow mouse stuff
        if(CheckPosition()) {
            mousePosition_ = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            direction = (mousePosition_ - transform.position).normalized;
            rb.velocity = new Vector3(direction.x * speed, direction.y * speed, direction.z * speed);
        }

        rb.transform.Rotate(0, 0, moveValueZ * speed);
    }

    void Controls () {
        if(Input.GetKey(KeyCode.A)) {
            //if(transform.rotation.z <= 0.5f || transform.rotation.z >= -0.5f) //trying to restrict the movement of the paddle
            moveValueZ = 0.5f;

        }
<<<<<<< Updated upstream
        if(Input.GetKey(KeyCode.D)) {
            moveValueZ = -0.5f;
=======
        if(Input.GetKey(KeyCode.D)) { //rotate cw

>>>>>>> Stashed changes
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            if(gameObject.GetComponent<GaugeBar>().spAtkBarImage.fillAmount > 0.5) {
                gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.5f);
                ShootSpecial();
            } else {
                Debug.Log("not enough PP for this");
            }
        }
        if(Input.GetKeyDown(KeyCode.E)) {
            rb.rotation = 0;
        }
    }
    
    bool CheckPosition() {
        if (transform.position.x > noMansLand.transform.position.x) {   //into no mans land center area, move left to go back
            rb.velocity = new Vector3(-speed, 0, 0);
            //Debug.Log("hit NML");
            return false;
        } else if (transform.position.y > topBorder.transform.position.y) {  //into upper border, move down to go back
            rb.velocity = new Vector3(0, -speed, 0);
            //Debug.Log("hit upper");
            return false;
        } else if (transform.position.y < bottomBorder.transform.position.y) { //into bottom border, move up to go back
            rb.velocity = new Vector3(0, speed, 0);
           //Debug.Log("hit bottom");
            return false;
        } else if (transform.position.x < leftBorder.transform.position.x) { //into left border, move right to go back
            rb.velocity = new Vector3(speed, 0, 0);
            //Debug.Log("hit left");
            return false;
        }
        return true; //position is good, keep doing what your doing :)
    }

    void UpdateHealth(int n) {
        hp -= n;
    }

    void ShootSpecial() {
        Instantiate(specAtk, shootPos.position, Quaternion.identity);
    }
}
