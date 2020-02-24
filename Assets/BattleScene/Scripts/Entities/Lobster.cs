using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobster : Enemy {
    //private float armAttackRate = 5.0f;
    float startTime, currentTime;
    public float armNextFire;
    List<GameObject> arms = new List<GameObject>();
    public GameObject Arm;
    public Transform Shoulder;

    public GameObject target;
    public float speed;
    public float maxAngularVelocity;

    Vector3 orientation;

    // Start is called before the first frame update
    void Start() {
        Init();
        isShootingAndMoving = true;
        armNextFire = 5.0f;
        target = FindObjectOfType<Paddle>().gameObject;
    }

    //Update is called once per frame
    void Update() {
        if (hasShot == true) {
            Init();
            Movement();
            hasShot = false;
        }
        if (isShootingAndMoving == true) {
            Fire();
        }

        else {
            rb.velocity = Vector2.zero;
        }
        currentTime = Time.time;
        ArmExtendAttack();
    }

    public void ArmExtendAttack() {

        if (Time.time > armNextFire) {
            isShootingAndMoving = false;

            armNextFire = Time.time + 10;
            //Enemy will freeze in place
            //Enemy will take a couple seconds to target the last spot where the paddle is


            {
                float dt = Time.deltaTime;
                Vector3 targetDir = (target.transform.position - transform.position).normalized;
                Vector3 pos = transform.position;

                float dotProduct = Vector3.Dot(targetDir, orientation) / orientation.magnitude;
                float angleBetween = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

                float angularDisplacement = maxAngularVelocity * dt;

                if (angleBetween <= angularDisplacement) {
                    orientation = targetDir.normalized;
                }
                else {
                    Vector2 normal = new Vector2(-orientation.y, orientation.x);
                    float normalDot = Vector2.Dot(normal, targetDir);

                    if (normalDot < 0) {
                        angularDisplacement *= -1;
                    }
                    angularDisplacement *= Mathf.Deg2Rad;
                    targetDir.x = (orientation.x * Mathf.Cos(angularDisplacement)) - (orientation.y * Mathf.Sin(angularDisplacement));
                    targetDir.y = (orientation.x * Mathf.Sin(angularDisplacement)) + (orientation.y * Mathf.Cos(angularDisplacement));

                    orientation = targetDir.normalized;

                }

                UpdateOrientation();

                Vector3 velocity = orientation * speed;

                pos = pos + (velocity * dt);
                transform.position = pos;
            } //Beginning stuff that'll lead to the enemy's arm
                //instantiating in the direction of the Paddle

            for (int i = 0; i < arms.Capacity; i++) {
                Vector3 armSegment = new Vector3(Shoulder.position.x + (-1 * i), Shoulder.position.y, Shoulder.position.z);

                Arm.transform.Translate(FindObjectOfType<Paddle>().transform.rotation.eulerAngles);

                arms.Add(Instantiate(Arm, armSegment, Arm.transform.rotation));
            }
            arms.Add(Instantiate(Arm, Shoulder.position, Arm.transform.rotation));
            //startTime = Time.time;
            //currentTime = 0;
            Arm.transform.Rotate(FindObjectOfType<Paddle>().transform.rotation.eulerAngles);
        }

        if (Time.time >= armNextFire - 5) { //time surpasses the time which the enemy is able to fire again...if enemy can attack
            hasShot = false; //set its ability to shoot to false

            if(isShootingAndMoving == false) {
                hasShot = true; //enemy is not moving or shooting 
            }
            isShootingAndMoving = true;

            for (int i = 0; i < arms.Capacity; i++) {
                Destroy(arms[i]);
            }
            arms.Clear();
        }
    }

    void UpdateOrientation() {
        Vector3 angle = new Vector3(0, 0, -Mathf.Atan2(orientation.x, orientation.y) * Mathf.Rad2Deg);
        transform.eulerAngles = angle;
    }
}
