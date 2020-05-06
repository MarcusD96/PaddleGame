using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : BaseEntity {

    public GameObject secondaryAtk;
    public GameObject[] specAtk = new GameObject[3];
    private Transform shootPos;
    private Rigidbody2D rb;
    private float startTime, minRot, maxRot, timeChange, nextFire = 0.0f, fireRate = 0.5f, specialNextFire = 0.0f, specialFireRate = 8.0f - GameState.GetStat((int)Stats.special), hitRate = 3.0f, nextHit = 0.0f;
    private Quaternion baseQuat;
    private Vector3 mousePosition_, direction;
    private PlayerBall ballHolder;
    private Transform Pos1, Pos2, TempPos;
    public SpriteRenderer sr;

    public GameObject ball;
    public Transform pos;
    private bool shoot;

    // Start is called before the first frame update
    private void Awake() {
        name = "Paddle"; //not 'clone'
        rb = GetComponent<Rigidbody2D>();

        shootPos = GetComponentInChildren<Transform>();

        transform.eulerAngles = new Vector3(0, 0, 180);

        minRot = 135;
        maxRot = minRot + 90;

        baseQuat = transform.rotation;

        moveSpeed = 400 + GameState.GetStat((int)Stats.speed);
        rotSpeed = 200 + GameState.GetStat((int)Stats.speed/2);

        SetHP(5);
        //TempCol = gameObject.GetComponent<Collider2D>();
        Pos1 = GetComponent<GetChildInfo>().end.transform;
        Pos2 = GetComponent<GetChildInfo>().body.transform;
        startTime = FindObjectOfType<BattleManager>().startTime;
        timeChange = Time.fixedDeltaTime;
    }

    private void FixedUpdate() { //vs fixed update?

        //follow mouse stuff
        mousePosition_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition_ - transform.position).normalized;
        rb.velocity = new Vector3(direction.x * moveSpeed * timeChange,
                                  direction.y * moveSpeed * timeChange,
                                  direction.z * moveSpeed * timeChange);

        Controls();

        if(ballHolder == null) {
            ballHolder = FindObjectOfType<PlayerBall>();
        } else if(ballHolder.transform.position.x < TempPos.position.x) {
            Physics2D.IgnoreCollision(ballHolder.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        } else {
            Physics2D.IgnoreCollision(ballHolder.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }

        if(Pos1.position.x < Pos2.position.x) {
            TempPos = Pos1;
        } else {
            TempPos = Pos2;
        }
    }

    // Update is called once per frame
    private void Update() {
        if(Time.time >= startTime + 3.0f && !shoot) {
            Instantiate(ball, pos.position, pos.rotation).GetComponent<PlayerBall>().SetSpeed(new Vector2(5, 5));
            sr.sprite = null;
            shoot = true;
        }
    }

    private void Controls() {
        //rotate left
        if(Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward, rotSpeed * timeChange);
        }

        //rotate right
        if(Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.back, rotSpeed * timeChange);
        }

        //shoot secondary continuously
        if(Input.GetKey(KeyCode.Space)) {
            if(Time.timeSinceLevelLoad >= nextFire) {
                if(gameObject.GetComponent<GaugeBar>().GetSpecialAttack().fillAmount > 0.2f) {
                    gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.2f);
                    nextFire = Time.timeSinceLevelLoad + fireRate;
                    ShootSecondary();
                }
            }
        }

        //shoot special
        if(Input.GetKey(KeyCode.LeftShift)) {
            if(Time.timeSinceLevelLoad >= specialNextFire) {
                if(gameObject.GetComponent<GaugeBar>().GetSpecialAttack().fillAmount > 0.5f) {
                    if(ShootSpecial()) {
                        gameObject.GetComponent<GaugeBar>().UpdatePlayerSpAtk(0.5f);
                    }

                    specialNextFire = Time.timeSinceLevelLoad + specialFireRate;
                }
            } else {
                Debug.Log("On cooldown");
            }
        }

        //rotate min left
        if(Input.GetKey(KeyCode.E)) {
            transform.rotation = Quaternion.Euler(0, 0, minRot);
        }

        //rotate max right
        if(Input.GetKey(KeyCode.Q)) {
            transform.rotation = Quaternion.Euler(0, 0, maxRot);

        }

        //center rotation
        if(Input.GetKey(KeyCode.F)) {
            transform.rotation = baseQuat;
        }

        //start scene
        if(Input.GetMouseButton(0)) {
            if(!shoot) {
                Instantiate(ball, pos.position, pos.rotation).GetComponent<PlayerBall>().SetSpeed(new Vector2(5, 5));
                sr.sprite = null;
                shoot = true;
            }
        }
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, minRot, maxRot);
        transform.localRotation = Quaternion.Euler(currentRotation);

    }

    private void ShootSecondary() {
        Instantiate(secondaryAtk, shootPos.position, secondaryAtk.transform.rotation);
    }

    private bool ShootSpecial() {
        if(GameState.EquippedWeapon == 4) {
            return false;
        } else {
            var atk = specAtk[GameState.EquippedWeapon];
            Instantiate(atk, shootPos.position, atk.transform.rotation);
            return true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(Time.timeSinceLevelLoad > nextHit) {
            if(collision.gameObject.CompareTag("Claw")) {
                TakeHit(1);
            }
            if(collision.gameObject.CompareTag("Shockwave")) {
                TakeHit(1);
            }
        }
    }

    public void TakeHit(int hit) {
        if(Time.timeSinceLevelLoad > nextHit) {
            nextHit = Time.timeSinceLevelLoad + hitRate;
            hp -= hit;
            StartCoroutine(Flash());
        }
    }

    IEnumerator Flash() {
        var paddle = gameObject.GetComponent<SpriteRenderer>();
        var tmp = paddle.sprite;

        var stop = Time.time + hitRate;
        do {
            paddle.sprite = null;
            yield return new WaitForSeconds(0.2f);
            paddle.sprite = tmp;
            yield return new WaitForSeconds(0.2f);
        } while(Time.time < stop);
    }
}
