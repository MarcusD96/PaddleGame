using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour {

    public GameObject noMansLand, topBorder, bottomBorder, leftBorder;

    Rigidbody2D rb;

    public float speed;
    private float moveValueZ;

    Vector3 mousePosition_, direction;

    // Start is called before the first frame update
    void Start () {
        tag = "Paddle";
        name = "Paddle";

        rb = GetComponent<Rigidbody2D>();

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
        if(Input.GetKey(KeyCode.D)) {
            moveValueZ = -0.5f;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            //FindObjectOfType<GaugeBar>().UpdatePlayerSpAtk(.5f);
            if(gameObject.GetComponent<GaugeBar>().spAtkBar.fillAmount > 0.5) {
                gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.5f); 
            Debug.Log("pew pew");
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
}
