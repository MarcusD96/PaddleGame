using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Lobster : Enemy {
    private FireArm fireArm;
    private ShockwaveAttack shockwaveAttack;
    private float armFireRate = 6.0f, armNextFire = 3.0f;
    public bool noMove; //if it can shoot, it cant move
    Vector2 speed;

    private int attackDecider = 1;

    // Start is called before the first frame update
    private void Start() {
        name = "Lobster Enemy";
        fireArm = GetComponent<FireArm>();
        shockwaveAttack = GetComponent<ShockwaveAttack>();
        speed = new Vector2(5, 5);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
    }

    //Update is called once per frame
    private void Update() {
        CheckMove();
        Movement(speed);
        Fire();

        switch (attackDecider) {
            case 0:
                noMove = fireArm.canShoot;
                if (Time.time > armNextFire) {
                    armNextFire = Time.time + armFireRate;
                    fireArm.canShoot = true; //allowed to shoot
                    attackDecider = Random.Range(0, 2);
                    //fireArm.shooting = true;
                }
                noMove = fireArm.canShoot;

                break;

            case 1:
                noMove = shockwaveAttack.canShoot;
                if (Time.time > armNextFire) {
                    armNextFire = Time.time + armFireRate;
                    shockwaveAttack.canShoot = true;
                    attackDecider = Random.Range(0, 2);
                }
                noMove = shockwaveAttack.canShoot;

                break;

            default:
                break;
        }
    }

    private void CheckMove() {
        if (noMove) {
            Movement(Vector2.zero);
        }
        else {
            if (rb.velocity.magnitude <= 0) {
                rb.velocity = speed;
            }
            Movement(speed);
        }
    }
}
