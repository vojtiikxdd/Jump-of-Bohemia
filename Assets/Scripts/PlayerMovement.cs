using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 6.0f;
    private float jumpingPower = 14f;
    public float maxJumpTime = 0.5f;
    public float jumpForceMultiplier = 5f; 
    private bool isJumping = false;
    private float jumpTimer = 0f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;

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
    }
    private void Jump()
    {
        float totalJumpForce = jumpingPower + jumpForceMultiplier * (jumpTimer / maxJumpTime);
        rb.AddForce(Vector3.up * totalJumpForce, ForceMode2D.Impulse);
    }

    private bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
