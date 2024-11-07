using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float speed = 5f; // Rychlost pohybu

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = 1f;
        }

        bool isWalking = moveDirection != 0f;
        animator.SetBool("isWalking", isWalking);

        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);

        // Otočení pomocí flipX
        if (moveDirection != 0f)
        {
            spriteRenderer.flipX = moveDirection < 0;
            Debug.Log("Move Direction: " + moveDirection + " | flipX: " + spriteRenderer.flipX);
        }
    }
}