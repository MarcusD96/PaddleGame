﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : BaseEntity {

    public GameObject secondaryAtk;
    public GameObject[] specAtk = new GameObject[3];
    private Transform shootPos;
    private Rigidbody2D rb;
    private float minRot, maxRot, dt, nextFire = 0.0f, fireRate = 0.5f, specialNextFire = 0.0f, specialFireRate = 2.0f, hitRate = 2.0f, nextHit = 0.0f;
    private Quaternion baseQuat;
    private Vector3 mousePosition_, direction;
    private Collider2D TempCol;
    private PlayerBall ballHolder;
    private Transform Pos1, Pos2, TempPos;

    public GameObject ball;
    public Transform pos;
    private bool shoot;

    // Start is called before the first frame update
    private void Awake() {
        name = "Paddle"; //not 'clone'
        rb = GetComponent<Rigidbody2D>();

        shootPos = GetComponentInChildren<Transform>();

        transform.eulerAngles = new Vector3(0, 0, 180);

        dt = Time.fixedDeltaTime;

        minRot = 135;
        maxRot = minRot + 90;

        baseQuat = transform.rotation;

        if(moveSpeed == 0) {
            moveSpeed = 500;
        }
        if(rotSpeed == 0) {
            rotSpeed = 200;
        }

        SetHP(5);
        TempCol = gameObject.GetComponent<Collider2D>();
        Pos1 = GetComponent<GetChildInfo>().end.transform;
        Pos2 = GetComponent<GetChildInfo>().body.transform;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        Controls();

        //follow mouse stuff
        mousePosition_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition_ - transform.position).normalized;
        rb.velocity = new Vector3(direction.x * moveSpeed * dt,
                                  direction.y * moveSpeed * dt,
                                  direction.z * moveSpeed * dt);

        if(ballHolder == null) {
            ballHolder = FindObjectOfType<PlayerBall>();
        } else if(ballHolder.transform.position.x < TempPos.position.x) {
            Physics2D.IgnoreCollision(ballHolder.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        } else {
            Physics2D.IgnoreCollision(ballHolder.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }

        if(Pos1.position.x < Pos2.position.x) {
            TempPos = Pos1;
        } else {
            TempPos = Pos2;
        }
    }

    private void Controls() {
        //rotate left
        if(Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward, rotSpeed * dt);
        }

        //rotate right
        if(Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.back, rotSpeed * dt);
        }

        //shoot secondary
        if(Input.GetKey(KeyCode.Space)) {
            if(Time.timeSinceLevelLoad >= nextFire) {
                if(gameObject.GetComponent<GaugeBar>().GetSpecialAttack().fillAmount > 0.2f) {
                    gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.2f);
                    nextFire = Time.timeSinceLevelLoad + fireRate;
                    ShootSecondary();
                } else {
                    Debug.Log("not enough PP for this");
                }
            } else {
                Debug.Log("On cooldown");
            }
        }

        //shoot special
        if(Input.GetKey(KeyCode.LeftShift)) {
            if(Time.timeSinceLevelLoad >= specialNextFire) {
                if(gameObject.GetComponent<GaugeBar>().GetSpecialAttack().fillAmount > 0.5f) {
                    gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.5f);
                    ShootSpecial();
                    specialNextFire = Time.timeSinceLevelLoad + specialFireRate;
                } else {
                    Debug.Log("not enough PP for this");
                }
            } else {
                Debug.Log("On cooldown");
            }
        }

        //rotate max left
        if(Input.GetKeyDown(KeyCode.E)) {
            transform.rotation = Quaternion.Euler(0, 0, minRot);
        }

        //rotate max right
        if(Input.GetKeyDown(KeyCode.Q)) {
            transform.rotation = Quaternion.Euler(0, 0, maxRot);
        }

        //center rotation
        if(Input.GetKeyDown(KeyCode.F)) {
            transform.rotation = baseQuat;
        }

        //start scene
        if(Input.GetMouseButtonDown(0)) {
            if(!shoot) {
                Instantiate(ball, pos.position, pos.rotation).GetComponent<PlayerBall>().SetSpeed(new Vector2(5, 5));
                shoot = true;
            }
        }
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, minRot, maxRot);
        transform.localRotation = Quaternion.Euler(currentRotation);

    }

    private void ShootSecondary() {
        Instantiate(secondaryAtk, shootPos.position, secondaryAtk.transform.rotation);
    }

    private void ShootSpecial() {
        if(GameState.EquippedWeapon == 0) {
            print("no special equipped");
        } else {
            var atk = specAtk[GameState.EquippedWeapon];
            Instantiate(atk, shootPos.position, atk.transform.rotation);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(Time.timeSinceLevelLoad > nextHit) {
            if(collision.gameObject.CompareTag("Claw")) {
                TakeHit(1);
            }
            if(collision.gameObject.CompareTag("Shockwave")) {
                TakeHit(1);
            }
        }
    }

    public void TakeHit(int hit) {
        if(Time.timeSinceLevelLoad > nextHit) {
            nextHit = Time.timeSinceLevelLoad + hitRate;
            hp -= hit;
            StartCoroutine(Flash(hitRate));
        }
    }

    IEnumerator Flash(float aTime) {
        float alpha = GetComponent<SpriteRenderer>().material.color.a;
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / (aTime / 4)) {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 0, t));
            GetComponent<SpriteRenderer>().material.color = newColor;
            yield return new WaitForSeconds(0);
        }
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / (aTime / 4)) {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 1, t));
            GetComponent<SpriteRenderer>().material.color = newColor;
            yield return new WaitForSeconds(0);
        }
    }


}
