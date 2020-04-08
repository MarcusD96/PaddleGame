using UnityEngine;

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

        if (hp <= startHP / 2) { //check for damaged state at teh end of attack
            if (!animator.GetBool("Damaged")) {
                animator.SetBool("Damaged", true);
            }
        }

        switch (attackDecider) {
            case 0:
                noMove = true;
                ArmFire();
                break;
            case 1:
                noMove = true;
                ArmFire();
                break;
            case 2:
                PerformShockwave();
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

    private void ArmFire() {
        if (shockwaveAttack.canShoot == false) {
            if (Time.timeSinceLevelLoad > armNextFire) {
                armNextFire = Time.timeSinceLevelLoad + armFireRate;
                fireArm.canShoot = noMove = true; //allowed to shoot
                attackDecider = Random.Range(0, 3);
            }
            animator.SetBool("isExtending is ", noMove);
            noMove = fireArm.canShoot;
        }
    }

    private void PerformShockwave() {
        if (fireArm.canShoot == false) {
            if (Time.timeSinceLevelLoad > armNextFire) {
                armNextFire = Time.timeSinceLevelLoad + armFireRate;
                shockwaveAttack.canShoot = noMove = true;
                attackDecider = Random.Range(0, 3);
            }
            animator.SetBool("isShocking", noMove); //if noMove is true, then it's going to be attacking
            noMove = shockwaveAttack.canShoot;
        }
    }
}
