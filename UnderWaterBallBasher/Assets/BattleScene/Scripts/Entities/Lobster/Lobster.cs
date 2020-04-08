﻿using UnityEngine;

public class Lobster : Enemy {
    private FireArm fireArm;
    private ShockwaveAttack shockwaveAttack;
    public Animator animator;
    private float armFireRate = 6.0f, armNextFire = 3.0f;
    public bool noMove; //if it can shoot, it cant move
    Vector2 speed;
    int startHP;

    private int attackDecider;

    // Start is called before the first frame update
    private void Start() {
        fireRate = 2.5f;
        name = "Lobster Enemy";
        fireArm = GetComponent<FireArm>();
        shockwaveAttack = GetComponent<ShockwaveAttack>();
        speed = new Vector2(4, 4);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
        animator.SetFloat("Speed", speed.sqrMagnitude);

        attackDecider = Random.Range(0, 3);
        SetHP(5);
        startHP = hp;
    }

    //Update is called once per frame
    private void FixedUpdate() {
        base.Update();
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        CheckMove();

        if(hp <= startHP / 2) { //check for damaged state at teh end of attack
            if(!animator.GetBool("Damaged")) {
                animator.SetBool("Damaged", true); 
            }
        }

        switch(attackDecider) {
            case 0:
                noMove = true;
                //Debug.Log(noMove + " in case 0");
                ArmFire();
                break;
            case 1:
                noMove = true;
                //Debug.Log(noMove + " in case 1");
                ArmFire();
                break;

            case 2:
                if(Time.timeSinceLevelLoad > armNextFire) {
                    armNextFire = Time.timeSinceLevelLoad + armFireRate;
                    shockwaveAttack.canShoot = noMove = true;
                    attackDecider = Random.Range(0, 3);
                    //Debug.Log("Hi in the shockwave attack");
                }
                animator.SetBool("isShocking", noMove); //if noMove is true, then its going to be atcking
                noMove = shockwaveAttack.canShoot;
                print(noMove + " after shockwave attack");
                break;

            default:
                break;
        }
    }

    private void CheckMove() {
        if(noMove) {
            Movement(Vector2.zero);
            Debug.Log("Hi");
        } else {
            if (rb.velocity.magnitude <= 0) {
                rb.velocity = speed;
            }
            Movement(speed);
        }
    }

    private void ArmFire() {
        //Debug.Log(noMove);
        noMove = fireArm.canShoot;
        Debug.Log(fireArm.canShoot + " fireArm.canShoot");
        if(Time.timeSinceLevelLoad > armNextFire) {
            armNextFire = Time.timeSinceLevelLoad + armFireRate;
            fireArm.canShoot = true; //allowed to shoot

            attackDecider = Random.Range(0, 3);
            //Debug.Log("Hi in ArmFire");
        }

        animator.SetBool("isExtending", noMove);
        noMove = fireArm.canShoot;
        //Debug.Log(noMove + " after armNextFire IF statement");
    }
}
