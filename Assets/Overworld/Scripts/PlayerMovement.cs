using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;

    private bool up = false, down = false, left = false, right = false;

    // Update is called once per frame
    void Update() { //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        if(movement.x > 0) {
            up = down = left = false;
            right = true;
        }
        if(movement.x < 0) {
            up = down = right = false;
            left = true;
        }
        animator.SetFloat("Vertical", movement.y);
        if(movement.y < 0) {
            up = left = right = false;
            down = true;
        }
        if(movement.y > 0) {
            left = down = right = false;
            up = true;
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);

        animator.SetBool("Up", up);
        animator.SetBool("Down", down);
        animator.SetBool("Left", left);
        animator.SetBool("Right", right);
    }

    void FixedUpdate() { //Movement Physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void CheckBools() {

    }
}
