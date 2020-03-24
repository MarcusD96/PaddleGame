using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveAttack : MonoBehaviour {
    public GameObject firstShockwave, secondShockwave, thirdShockwave;
    public Transform pos;
    public List<GameObject> shockwaves;

    public bool canShoot = false;
    private bool shooting = false;


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
                StartCoroutine(FireShockwaves());
            }
        }
    }

    public IEnumerator FireShockwaves() {
        shooting = true;

        int NumOfShockwavesSpawned = Random.Range(2, 5);

        for (int i = 0; i < NumOfShockwavesSpawned; i++) {

            yield return new WaitForSeconds(1.0f);

            int spawnShockwave = Random.Range(0, 3);

            var sw = shockwaves[spawnShockwave];

            GameObject tmp = Instantiate(sw, pos.position, sw.transform.rotation);

            tmp.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
        }

        shooting = canShoot = false;
    }
}
