using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Lobster : Enemy {
    private FireArm fireArm;
    private new float fireRate = 6.0f, nextFire = 3.0f;

    // Start is called before the first frame update
    void Start() {
        Init();
        fireArm = GetComponent<FireArm>();
    }

    //Update is called once per frame
    void FixedUpdate() {
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            fireArm.canShoot = true;
        }
    }
}
