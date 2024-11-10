using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class WalkingSoundController : MonoBehaviour
{
    public AudioSource walkingAudioSource; // Reference to the AudioSource component
    public AudioClip lowHeightSound;
    public AudioClip midHeightSound;
    public AudioClip highHeightSound;

    void Update()
    {
        // Check the player's current height (Y-axis position)
        float playerHeight = transform.position.y;

        // Choose the sound based on the height
        if (playerHeight < -1)
        {
            walkingAudioSource.clip = lowHeightSound;
        }
        else if (playerHeight < 2)
        {
            walkingAudioSource.clip = midHeightSound;
        }
        else
        {
            walkingAudioSource.clip = highHeightSound;
        }

        // Play the walking sound only if 'A' or 'D' is pressed and the sound is not already playing
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && !walkingAudioSource.isPlaying)
        {
            walkingAudioSource.Play();
        }

        // Stop the sound when none of the keys are pressed
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            walkingAudioSource.Stop();
        }
    }
}
