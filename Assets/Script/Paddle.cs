using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour {

    public GameObject specAtk;
    Transform shootPos;

    Rigidbody2D rb;

    public float speed, rotSpeed, hp;
    float rotation = 0f, dt;

    Vector3 mousePosition_, direction;

    // Start is called before the first frame update
    void Start() {
        tag = "Paddle";
        name = "Paddle";

        rb = GetComponent<Rigidbody2D>();

        shootPos = GetComponentInChildren<Transform>();

        dt = Time.deltaTime;

        if(speed == 0) {
            speed = 250;
        }
        if(rotSpeed == 0) {
            rotSpeed = 1;
        }
        if(hp < 0) {
            hp = 10;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {

        Controls();

        //follow mouse stuff
        mousePosition_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition_ - transform.position).normalized;
        rb.velocity = new Vector3(direction.x * speed * dt,
                                  direction.y * speed * dt,
                                  direction.z * speed * dt);
        //print((int) transform.eulerAngles.z);
    }

    void Controls() {
        if(Input.GetKey(KeyCode.A)) { //rotate ccw
            
        }
        if(Input.GetKey(KeyCode.D)) { //rotate cw
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)) { //shoot special
            if(gameObject.GetComponent<GaugeBar>().spAtkBarImage.fillAmount > 0.5) {
                gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.5f);
                ShootSpecial();
            } else {
                Debug.Log("not enough PP for this");
            }
        }
        if(Input.GetKeyDown(KeyCode.E)) {
            transform.rotation = Quaternion.identity;
        }

    }

    void UpdateHealth(float n) {
        hp -= n;
    }

    void ShootSpecial() {
        Instantiate(specAtk, shootPos.position, specAtk.transform.rotation);
    }
}
