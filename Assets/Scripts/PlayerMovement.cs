using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 6.0f;
    private float jumpingPower = 12f;
    public float maxJumpTime = 0.5f;
    public float jumpForceMultiplier = 5f; 
    private bool isJumping = false;
    private float jumpTimer = 0f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    public bool isGroundedFlag;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        isGroundedFlag = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && isGroundedFlag)
        {
            isJumping = true;
            jumpTimer = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            jumpTimer += Time.deltaTime;
            jumpTimer = Mathf.Clamp(jumpTimer, 0f, maxJumpTime);
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && isJumping)
        {
            Jump();
            isJumping = false;
        }

        Flip();

        // if (Input.GetButtonDown("Jump") && isGrounded())
        // {
            
        //     // rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        // }

        // if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) 
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        //     //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        // }

        
    }
    private void Jump()
    {
        float totalJumpForce = jumpingPower + jumpForceMultiplier * (jumpTimer / maxJumpTime);
        rb.AddForce(Vector3.up * totalJumpForce, ForceMode2D.Impulse);
    }

    private bool CheckIfGrounded()
    {
        // if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, 0);
        // }   

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        //Vector2 velocity = rb.velocity;
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
