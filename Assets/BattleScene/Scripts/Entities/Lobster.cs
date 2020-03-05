using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Lobster : Enemy {
    private FireArm fireArm;
    private new float fireRate = 6.0f, nextFire = 3.0f;
    private bool noMove = true;
    
    // Start is called before the first frame update
    void Start() {
        fireArm = GetComponent<FireArm>();
    }

    //Update is called once per frame
    void FixedUpdate() {
        noMove = fireArm.canShoot;
        CheckMove();
        Movement();
        Fire();
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            fireArm.canShoot = true;
        }
    }

    void CheckMove() {
        if (!noMove) {
            constantSpeed = Vector2.zero;
        } else {
            constantSpeed = new Vector2(5, 5);
        }
    }
}
