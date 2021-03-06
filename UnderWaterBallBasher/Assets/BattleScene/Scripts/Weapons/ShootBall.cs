﻿using UnityEngine;

public class ShootBall : MonoBehaviour {
    public GameObject ball;
    public Transform pos;
    private bool shoot;

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            if(!shoot) {
                Instantiate(ball, pos.position, pos.rotation).GetComponent<PlayerBall>().SetSpeed(new Vector2(5, 5));
                shoot = true;
            }            
        }
    }
}