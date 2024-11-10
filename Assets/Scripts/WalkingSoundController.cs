using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSoundController : MonoBehaviour
{
    public AudioSource walkingAudioSource;
    public AudioClip lowHeightSound;
    public AudioClip midHeightSound;
    public AudioClip highHeightSound;

    public LayerMask groundLayer; // Layer for the ground
    public Transform groundCheck; // A point to check if the player is on the ground
    public float groundCheckRadius = 0.2f; // Radius of the ground check

    private bool isGrounded;

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Check the player's current height (Y-axis position)
        float playerHeight = transform.position.y;

        // Choose the sound based on the height
        if (playerHeight < 10)
        {
            walkingAudioSource.clip = lowHeightSound;
        }
        else if (playerHeight < 20)
        {
            walkingAudioSource.clip = midHeightSound;
        }
        else
        {
            walkingAudioSource.clip = highHeightSound;
        }

        // Play the walking sound only if on ground, movement keys are pressed, and sound isn't already playing
        if (isGrounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && !walkingAudioSource.isPlaying)
        {
            walkingAudioSource.Play();
        }

        // Stop the sound if the player is not on the ground or stops pressing movement keys
        if (!isGrounded || (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)))
        {
            walkingAudioSource.Stop();
        }
    }
}
