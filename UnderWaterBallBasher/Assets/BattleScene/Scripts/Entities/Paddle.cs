using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : BaseEntity {

    public GameObject specAtk;
    private Transform shootPos;
    private Rigidbody2D rb;
    private float minRot, maxRot, dt, nextFire = 0.0f, fireRate = 0.5f, hitRate = 1.0f, nextHit = 0.0f;
    private Quaternion baseQuat;
    private Vector3 mousePosition_, direction;
    private Collider2D TempCol;
    public PlayerBall ballHolder;
    private Transform Pos1, Pos2, TempPos;

    // Start is called before the first frame update
    private void Awake() {
        name = "Paddle"; //not 'clone'
        rb = GetComponent<Rigidbody2D>();

        shootPos = GetComponentInChildren<Transform>();

        transform.eulerAngles = new Vector3(0, 0, 180);

        dt = Time.fixedDeltaTime;

        minRot = 135;
        maxRot = minRot + 90;

        baseQuat = transform.rotation;

        if(moveSpeed == 0) {
            moveSpeed = 400;
        }
        if(rotSpeed == 0) {
            rotSpeed = 150;
        }

        SetHP(5);
        TempCol = gameObject.GetComponent<Collider2D>();
        Pos1 = GetComponent<GetChildInfo>().end.transform;
        Pos2 = GetComponent<GetChildInfo>().body.transform;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        Controls();

        //follow mouse stuff
        mousePosition_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition_ - transform.position).normalized;
        rb.velocity = new Vector3(direction.x * moveSpeed * dt,
                                  direction.y * moveSpeed * dt,
                                  direction.z * moveSpeed * dt);

        if (ballHolder == null) {
            ballHolder = FindObjectOfType<PlayerBall>();
        }

        if (Pos1.position.x < Pos2.position.x) {
            TempPos = Pos1;
        } else {
            TempPos = Pos2;
        }

        if (ballHolder.transform.position.x < TempPos.position.x) {
            Physics2D.IgnoreCollision(ballHolder.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
        else {
            Physics2D.IgnoreCollision(ballHolder.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }
    }

    private void Controls() {
        if(Input.GetKey(KeyCode.A)) { //rotate ccw
            transform.Rotate(Vector3.forward, rotSpeed * dt);
        }
        if(Input.GetKey(KeyCode.D)) { //rotate cw
            transform.Rotate(Vector3.back, rotSpeed * dt);
        }
        if(Input.GetKey(KeyCode.Space)) { //shoot secondary
            if(Time.time >= nextFire) {
                nextFire = Time.time + fireRate;
                if(gameObject.GetComponent<GaugeBar>().GetSpecialAttack().fillAmount > 0.2f) {
                    gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.2f);
                    ShootSecondary();
                } else {
                    Debug.Log("not enough PP for this");
                }
            } else {
                Debug.Log("On cooldown");
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)) { //shoot special
            if(Time.time >= nextFire) {
                nextFire = Time.time + fireRate;
                if(gameObject.GetComponent<GaugeBar>().GetSpecialAttack().fillAmount > 0.5f) {
                    gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.5f);
                    //ShootSpecial();
                } else {
                    Debug.Log("not enough PP for this");
                }
            } else {
                Debug.Log("On cooldown");
            }
        }
        if(Input.GetKeyDown(KeyCode.E)) {
            transform.rotation = Quaternion.Euler(0, 0, minRot);
        }
        if(Input.GetKeyDown(KeyCode.Q)) {
            transform.rotation = Quaternion.Euler(0, 0, maxRot);
        }
        if(Input.GetKeyDown(KeyCode.F)) {
            transform.rotation = baseQuat;
        }
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, minRot, maxRot);
        transform.localRotation = Quaternion.Euler(currentRotation);

    }

    private void ShootSecondary() {
        Instantiate(specAtk, shootPos.position, specAtk.transform.rotation);
    }

    private void ShootSpecial() {
        Instantiate(specAtk, shootPos.position, specAtk.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(Time.time > nextHit) {
            if(collision.gameObject.CompareTag("Claw")) {
                nextHit = Time.time + hitRate;
                TakeHit(1);
            }
        }
    }
    
    public void TakeHit(int hit) {
        if(Time.time > nextHit) {
            nextHit = Time.time + hitRate;
            hp -= hit;
            StartCoroutine(Flash(hitRate));
        }
    }

    IEnumerator Flash(float aTime) {
        float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / (aTime / 4)) {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 0, t));
            transform.GetComponent<SpriteRenderer>().material.color = newColor;
            yield return new WaitForSeconds(0);
        }
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / (aTime / 4)) {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 1, t));
            transform.GetComponent<SpriteRenderer>().material.color = newColor;
            yield return new WaitForSeconds(0);
        }
    }

    
}
