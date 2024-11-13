using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 6.0f;
    private float jumpingPower = 14f;
    public float maxJumpTime = 0.5f;
    public float jumpForceMultiplier = 5f;
    private bool canJump = false;
    private float jumpTimer = 0f;
    private bool isFacingRight = true;
    public float bounceForce = 10f;
    public bool isGroundedFlag;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;

    private PlayerSoundJump playerSoundJump; // Reference to the PlayerSoundJump script

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSoundJump = GetComponent<PlayerSoundJump>(); // Get the PlayerSoundJump script
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Update grounded status
        isGroundedFlag = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Allow jump if grounded
        if (isGroundedFlag && !canJump)
        {
            canJump = true;
            jumpTimer = 0f;
        }

        // Handle jump input and timing
        HandleJumpInput();

        // Flip character based on movement direction
        Flip();
    }

    private void FixedUpdate()
    {
        // Update movement only in FixedUpdate for consistency with physics
        
        // if(!isgroundedFlag && rb.velocity.y < 0)
        // {
        //     rb.velocity = new Vector2(0,0);
        // }
        // else
            MovePlayer();
    }

    private void HandleJumpInput()
    {
        // Start jump on initial space press
        if (Input.GetKeyDown(KeyCode.Space) && isGroundedFlag && canJump)
        {
            jumpTimer = 0f; // Reset jump timer at the start of a new jump
        }

        // Track jump hold time while space is held
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            jumpTimer += Time.deltaTime;
            jumpTimer = Mathf.Clamp(jumpTimer, 0f, maxJumpTime);
        }

        // Release jump and apply force
        if (Input.GetKeyUp(KeyCode.Space) && canJump)
        {
            Jump();
            playerSoundJump?.PlayJumpSound(); // Play the jump sound if script is attached
            canJump = false;
        }

        
    }

    private void MovePlayer()
    {
        // Set horizontal movement, preserving vertical velocity
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Jump()
    {
        // Calculate total jump force based on how long the player held the jump button
        float totalJumpForce = jumpingPower + jumpForceMultiplier * (jumpTimer / maxJumpTime);
        
        // Apply jump force directly to y-axis of velocity
        rb.velocity = new Vector2(rb.velocity.x, totalJumpForce);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f); // Flip the player
        }
    }
}
