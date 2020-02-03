using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{

    public Rigidbody2D rb;
    //public Transform t;

    public float speed;
    private float moveValue, moveValueZ;
    private float ZeroAngle, NinetyAngle;
    // Start is called before the first frame update
    void Start()
    {
        tag = "Paddle";
        name = "Paddle";

        rb = GetComponent<Rigidbody2D>();

        if (speed == 0)
        {
            speed = 5;
        }

        ZeroAngle = rb.rotation;
        NinetyAngle = ZeroAngle + 90;
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = 0;
        moveValueZ = 0;
        Controls();
        if (rb)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveValue * speed);
            rb.transform.Rotate(0, 0, moveValueZ * speed);
        }
    }

    void Controls()
    {
        /*
        switch (Input.anyKeyDown.ToString().ToLower())
        {
            case "w":  //ball hits paddle
                moveValue = 1;
                break;

            case "s": //ball hits enemy side wall
                moveValue = -1;
                break;

            case "a":    //ball hits player side wall
                moveValueZ = 1;
                break;

            case "d":
                moveValueZ = 1;
                break;

            case "e":  //ball hits top or bottom wall
                rb.rotation = ZeroAngle;
                break;

            case "q":  //ball hits top or bottom wall
                rb.rotation = NinetyAngle;
                break;

            default:
                break;
        }*/
        if (Input.GetKey(KeyCode.W))
        {
            moveValue = 0.75f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveValue = -0.75f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //if(transform.rotation.z <= 0.5f || transform.rotation.z >= -0.5f) //trying to restrict the movement of the paddle
                moveValueZ = 0.5f;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveValueZ = -0.5f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            FindObjectOfType<GaugeBar>().UpdatePlayerSpAtk(.5f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.rotation = NinetyAngle;
        }
    }
}
