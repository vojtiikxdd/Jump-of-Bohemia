using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_re : MonoBehaviour
{
    public float walkSpeed = 4f;
    private float moveInput;
    public bool isGrounded = true;
    private Rigidbody2D rb;
    public LayerMask groundMask;
    //[SerializeField] private Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    public bool canJump = true;
    public float jumpValue = 0.0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2 (moveInput * walkSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, 0.1f, groundMask);
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if(Input.GetButtonDown("Jump") && isGrounded && canJump){
            jumpValue += 0.1f;
        }

        if(jumpValue >= 20f && isGrounded){
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2 (tempx, tempy);
            Invoke("ResetJump", 0.2f);
        }

        if(Input.GetButtonUp("Jump")){
            canJump = true;
        }
    }

    void ResetJump(){
        jumpValue = 0.0f;
        canJump = false;
    }
}
