using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : BaseEntity {

    public GameObject specAtk;
    Transform shootPos;

    Rigidbody2D rb;

    private float minRot, maxRot, dt, nextF, FRate;

    private Quaternion baseQuat;

    Vector3 mousePosition_, direction;

    // Start is called before the first frame update
    void Start() {
        tag = "Paddle";
        name = "Paddle";

        rb = GetComponent<Rigidbody2D>();

        shootPos = GetComponentInChildren<Transform>();

        transform.eulerAngles = new Vector3(0, 0, 180);

        dt = Time.fixedDeltaTime;

        minRot = 135;
        maxRot = minRot + 90;

        baseQuat = transform.rotation;

        if (moveSpeed == 0) {
            moveSpeed = 500;
        }
        if (rotSpeed == 0) {
            rotSpeed = 150;
        }
        SetHP(5);

        FRate = 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate() {
        Controls();

        //follow mouse stuff
        mousePosition_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition_ - transform.position).normalized;
        rb.velocity = new Vector3(direction.x * moveSpeed * dt,
                                  direction.y * moveSpeed * dt,
                                  direction.z * moveSpeed * dt);
    }

    void Controls() {
        if (Input.GetKey(KeyCode.A)) { //rotate ccw
            transform.Rotate( Vector3.forward, rotSpeed * dt);  
        }
        if (Input.GetKey(KeyCode.D)) { //rotate cw
            transform.Rotate(Vector3.back, rotSpeed * dt);
        }
        if (Input.GetKey(KeyCode.Space)) { //shoot secondary
            if (Time.time >= nextF) {
                nextF = Time.time + FRate;
                if (gameObject.GetComponent<GaugeBar>().spAtkBarImage.fillAmount > 0.2f) {
                    gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.2f);
                    ShootSecondary();
                }
                else {
                    Debug.Log("not enough PP for this");
                }
            }
            else {
                Debug.Log("On cooldown");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) { //shoot special
            if (Time.time >= nextF) {
                nextF = Time.time + FRate;
                if (gameObject.GetComponent<GaugeBar>().spAtkBarImage.fillAmount > 0.5f) {
                    gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.5f);
                    ShootSpecial();
                }
                else {
                    Debug.Log("not enough PP for this");
                }
            }
            else {
                Debug.Log("On cooldown");
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            transform.rotation = Quaternion.Euler(0, 0, minRot);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            transform.rotation = Quaternion.Euler(0, 0, maxRot);
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            transform.rotation = baseQuat;
        }
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, minRot, maxRot);
        transform.localRotation = Quaternion.Euler(currentRotation);

    }

    void UpdateHealth(int n) {
        hp -= n;
    }

    void ShootSecondary() {
        Instantiate(specAtk, shootPos.position, specAtk.transform.rotation);
    }
    void ShootSpecial() {
        Instantiate(specAtk, shootPos.position, specAtk.transform.rotation);
    }
}
