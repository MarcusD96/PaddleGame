using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Lobster : Enemy {
    private FireArm fireArm;
    private float armFireRate = 6.0f, armNextFire = 3.0f;
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
        if (Time.time > armNextFire) {
            armNextFire = Time.time + armFireRate;
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
