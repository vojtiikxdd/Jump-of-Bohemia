using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_re : MonoBehaviour
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
}
