using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMoving : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Move(bool isMoving,Animator animator) {
            animator.SetBool("Run", true);
            float moveSpeed = isMoving ? speed : -speed;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

    }
}
