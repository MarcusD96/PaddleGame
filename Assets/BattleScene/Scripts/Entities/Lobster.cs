using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Lobster : Enemy {
    private FireArm fireArm;
    private float armFireRate = 6.0f, armNextFire = 3.0f;
    public bool noMove; //if it can shoot, it cant move
    Vector2 speed;

    // Start is called before the first frame update
    private void Start() {
        name = "Lobster Enemy";
        fireArm = GetComponent<FireArm>();
        noMove = fireArm.canShoot;
        speed = new Vector2(5, 5);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
    }

    //Update is called once per frame
    private void LateUpdate() {
        CheckMove();
        Movement(speed);
        Fire();
        if(Time.time > armNextFire) {
            armNextFire = Time.time + armFireRate;
            fireArm.canShoot = true; //allowed to shoot
        }
        noMove = fireArm.canShoot;
    }

    private void CheckMove() {
        if(noMove) {
            Movement(Vector2.zero);
        } else {
            if (rb.velocity.magnitude <= 0) {
                rb.velocity = speed;
            }
            Movement(speed);
        }
    }
}
