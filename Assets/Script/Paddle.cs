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

    private bool IfNML;

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

        IfNML = false;
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

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Projectile") {
            hp--;
            //FindObjectOfType<GaugeBar>().UpdatePlayerHealth(0.1f);
        }
    }

    void ShootSpecial() {
        Instantiate(specAtk, shootPos.position, specAtk.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "NML") {
            IfNML = true;
            rb.velocity = Vector2.zero;
            rb.MovePosition(new Vector2(noMansLand.transform.position.x - (rb.position.x - (rb.position.x - (GetComponent<Collider2D>().bounds.size.x + 0.2f))), rb.position.y));
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "NML") {
            IfNML = false;
        }
    }
}
