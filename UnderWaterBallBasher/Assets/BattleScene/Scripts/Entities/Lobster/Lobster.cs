using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Lobster : Enemy {
    private FireArm fireArm;
    private ShockwaveAttack shockwaveAttack;
    public Animator animator;
    private float armFireRate = 6.0f, armNextFire = 3.0f;
    public bool noMove; //if it can shoot, it cant move
    Vector2 speed;

    private int attackDecider;

    // Start is called before the first frame update
    private void Start() {
        name = "Lobster Enemy";
        fireArm = GetComponent<FireArm>();
        shockwaveAttack = GetComponent<ShockwaveAttack>();
        speed = new Vector2(4, 4);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
        animator.SetFloat("Speed", speed.sqrMagnitude);
        attackDecider = 3;
        SetHP(5);
    }

    //Update is called once per frame
    private void FixedUpdate() {
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        CheckMove();
        Fire();

        switch(attackDecider) {
            case 0:
                noMove = true;
                ArmFire();
                break;
            case 1:
                noMove = true;
                ArmFire();
                break;
            case 2:
                noMove = true;
                ArmFire();
                break;

            case 3:
                //noMove = shockwaveAttack.canShoot;
                if(Time.timeSinceLevelLoad > armNextFire) {
                    armNextFire = Time.timeSinceLevelLoad + armFireRate;
                    shockwaveAttack.canShoot = true;
                    attackDecider = Random.Range(0, 4);
                }
                noMove = shockwaveAttack.canShoot;
                break;

            default:
                break;
        }
    }

    private void CheckMove() {
        if(noMove) {
            Movement(Vector2.zero);
        } else {
            if(rb.velocity.magnitude <= 0) {
                rb.velocity = speed;
            }
            Movement(speed);
        }
    }

    private void ArmFire() {
        noMove = fireArm.canShoot;
        if(Time.timeSinceLevelLoad > armNextFire) {
            armNextFire = Time.timeSinceLevelLoad + armFireRate;
            fireArm.canShoot = true; //allowed to shoot
            attackDecider = Random.Range(0, 4);
        }
        noMove = fireArm.canShoot;
    }
}
