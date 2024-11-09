using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip lowAltitudeClip;
    public AudioClip midAltitudeClip;
    public AudioClip highAltitudeClip;
    public Transform playerTransform; // Reference to the player's Transform
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float playerHeight = playerTransform.position.y;

        if (playerHeight < -1) // Low altitude
        {
            PlayClip(lowAltitudeClip);
        }
        else if (playerHeight < 2) // Mid altitude
        {
            PlayClip(midAltitudeClip);
        }
        else // High altitude
        {
            PlayClip(highAltitudeClip);
        }
    }

    private void PlayClip(AudioClip clip)
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}