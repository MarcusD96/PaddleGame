using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour {

    public GameObject specAtk, noMansLand, topBorder, bottomBorder, leftBorder;
    Transform shootPos;

    Rigidbody2D rb;

    public float speed = 1;
    public int hp = 5;
    private float moveValueZ;

    Vector3 mousePosition_, direction;

    private bool IfNML;

    // Start is called before the first frame update
    void Start() {
        tag = "Paddle";
        name = "Paddle";

        rb = GetComponent<Rigidbody2D>();

        shootPos = GetComponentInChildren<Transform>();

        if (speed == 0) {
            speed = 20;
        }

        IfNML = false;
    }

    // Update is called once per frame
    void Update() {

        moveValueZ = 0;
        Controls();

        //follow mouse stuff
        if (IfNML == false) {
            mousePosition_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition_ - transform.position).normalized;
            rb.velocity = new Vector3(direction.x * speed, direction.y * speed, direction.z * speed);
        }

        if (IfNML) {
            Debug.Log(noMansLand.transform.position.x);
        }

        if (IfNML == true && Input.mousePosition.x < noMansLand.transform.position.x) {
            IfNML = false;
        }
        rb.transform.Rotate(0, 0, moveValueZ * speed);

    }

    void Controls() {
        if (Input.GetKey(KeyCode.A)) {
            //if(transform.rotation.z <= 0.5f || transform.rotation.z >= -0.5f) //trying to restrict the movement of the paddle
            moveValueZ = 0.5f;

        }
        if (Input.GetKey(KeyCode.D)) {
            moveValueZ = -0.5f;
        }
        //if (Input.GetKeyDown(KeyCode.LeftShift)) {
        //    if (gameObject.GetComponent<GaugeBar>().spAtkBarImage.fillAmount > 0.5) {
        //        gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.5f);
        //        ShootSpecial();
        //    }
        //    else {
        //        Debug.Log("not enough PP for this");
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.E)) {
            rb.rotation = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Projectile") {
            hp--;
            //FindObjectOfType<GaugeBar>().UpdatePlayerHealth(0.1f);
        }
    }

    void ShootSpecial() {
        Instantiate(specAtk, shootPos.position, Quaternion.identity);
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
