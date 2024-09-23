using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 4.0f;
    private float jumpingPower = 16.0f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) 
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private bool isGrounded()
    {
        // if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, 0);
        // }   

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // if (horizontal > 0f && !isFacingRight)
        // {
        //     Flip();
        // }
        // else if (horizontal < 0f && isFacingRight)
        // {
        //     Flip();
        // }
    }

    private void Flip()
    {
        // isFacingRight = !isFacingRight;
        // transform.Rotate(0f, 180f, 0f);

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
