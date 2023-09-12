using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f;
    public Animator animatorChar;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(bool isMovingRight)
    {
        float moveSpeed = isMovingRight ? speed : -speed;
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        animatorChar.SetBool("Run", true);
    }

}
