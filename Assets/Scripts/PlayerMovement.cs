using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;

    public bool canJump = true;
    public float jumpValue = 0.0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(transform.position, 0.5f, groundMask);

        if(Input.GetKey("space") && isGrounded && canJump){
            jumpValue += 0.1f;
        }

        if(jumpValue >= 20f && isGrounded){
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
        }
    }

    // private float horizontal;
    // private float speed = 6.0f;
    // private float jumpingPower = 14f;
    // public float maxJumpTime = 0.5f;
    // public float jumpForceMultiplier = 5f;
    // private bool canJump = false;
    // private float jumpTimer = 0f;
    // private bool isFacingRight = true;
    // public float bounceForce = 10f;

    // [SerializeField] private Rigidbody2D rb;
    // [SerializeField] private Transform groundCheck;
    // [SerializeField] private LayerMask groundLayer;
    // public float groundCheckRadius = 0.1f;

    // private PlayerSoundJump playerSoundJump; // Reference to the PlayerSoundJump script

    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    //     playerSoundJump = GetComponent<PlayerSoundJump>(); // Get the PlayerSoundJump script
    // }

    // void Update()
    // {
    //     horizontal = Input.GetAxisRaw("Horizontal");

    //     // Update grounded status
    //     bool isGroundedFlag = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    //     if (jumpTimer == 0.0f && isGroundedFlag)
    //     {
    //         rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    //     }

    //     // Reset canJump only when the player is grounded
    //     if (isGroundedFlag && !canJump)
    //     {
    //         canJump = false;
    //     }

    //     // Start jump if grounded and space is pressed
    //     if (Input.GetKeyDown(KeyCode.Space) && isGroundedFlag)
    //     {
    //         canJump = true;
    //         jumpTimer = 0f;
    //     }

    //     if (Input.GetKey("space") && isGroundedFlag && canJump){
    //         rb.velocity = new Vector2(0.0f, rb.velocity.y);
    //     }

    //     // Track jump hold time
    //     if (Input.GetKey(KeyCode.Space) && canJump)
    //     {
    //         jumpTimer += Time.deltaTime;
    //         jumpTimer = Mathf.Clamp(jumpTimer, 0f, maxJumpTime);
    //     }

    //     // Release jump and play sound
    //     if (Input.GetKeyUp(KeyCode.Space) && canJump)
    //     {
    //         Jump();
    //         playerSoundJump.PlayJumpSound(); // Play the jump sound
    //         canJump = false;
    //     }

    //     Flip(); 
    // }

    // private void Jump()
    // {
    //     float totalJumpForce = jumpingPower + jumpForceMultiplier * (jumpTimer / maxJumpTime);
    //     rb.AddForce(Vector3.up * totalJumpForce, ForceMode2D.Impulse);
    // }

    // // private void FixedUpdate()
    // // {
    // //     rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    // // }

    // private void Flip()
    // {
    //     if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
    //     {
    //         isFacingRight = !isFacingRight;
    //         transform.Rotate(0f, 180f, 0f);
    //     }
    // }
}
