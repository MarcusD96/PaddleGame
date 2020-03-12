using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchShockwave : Projectile {
    // Start is called before the first frame update


    void Start() {
        if (x == 0) {
            x = -3;
        }
        if (y == 0) {
            y = 0;
        }

        BallStart();
        tag = "Shockwave";

        rb.velocity = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update() {

    }
}
