using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveAttack : MonoBehaviour {
    public GameObject firstShockwave, secondShockwave, thirdShockwave;
    public Transform pos;
    public List<GameObject> shockwaves;
    public Animator animator; 

    public bool canShoot = false;
    private bool shooting = false;
    public bool isAnimating = true;


    // Start is called before the first frame update
    void Start() {
        shockwaves.Add(firstShockwave);
        shockwaves.Add(secondShockwave);
        shockwaves.Add(thirdShockwave);

        foreach (var i in FindObjectsOfType<Transform>()) {
            if (i.CompareTag("ShockwaveAttack")) {
                pos = i;
                break;
            }
        }
    }

    private void FixedUpdate() {
        if (!shooting) {
            if (canShoot) {
                //animator.SetBool("isShocking", true);

                StartCoroutine(FireShockwaves());
            }
        }
    }

    public IEnumerator FireShockwaves() {
        shooting = true;

        int NumOfShockwavesSpawned = Random.Range(2, 5);


        for (int i = 0; i < NumOfShockwavesSpawned; i++) {

            if (isAnimating == true) {
                animator.SetBool("isShocking", true);
            }

            yield return new WaitForSeconds(1.0f);

            int spawnShockwave = Random.Range(0, 3);

            var sw = shockwaves[spawnShockwave];

            GameObject tmp = Instantiate(sw, pos.position, sw.transform.rotation);

            tmp.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;

            isAnimating = false;
        }
        animator.SetBool("isShocking", false);

        shooting = canShoot = false;
        isAnimating = true;
    }
}
