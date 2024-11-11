using UnityEngine;

public class PlayerLanding2D : MonoBehaviour
{
    public AudioSource audioSource;            // Reference to AudioSource component
    public AudioClip normalLandingSound;       // Sound for normal landing
    public AudioClip hardLandingSound;         // Sound for hard landing
    public float hardLandingDistance = 5f;     // Distance threshold for hard landing
    public float minimumFallHeight = 1f;       // Minimum fall height to trigger any landing sound

    private Rigidbody2D rb;
    private bool isFalling = false;            // Flag to check if player is falling
    private float startFallHeight;             // Y position where the player started falling

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Start tracking fall if the player begins moving downward
        if (rb.velocity.y < 0 && !isFalling)
        {
            isFalling = true;
            startFallHeight = transform.position.y; // Capture height at start of fall
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Only play sound if the player lands on an object tagged "Ground"
        if (isFalling && collision.gameObject.CompareTag("Ground"))
        {
            float fallDistance = startFallHeight - transform.position.y;

            // Check if the fall distance meets the minimum threshold for sound
            if (fallDistance >= minimumFallHeight)
            {
                // Play hard landing sound if the fall distance exceeds hard landing threshold
                if (fallDistance >= hardLandingDistance)
                {
                    audioSource.PlayOneShot(hardLandingSound);
                }
                else
                {
                    audioSource.PlayOneShot(normalLandingSound);
                }
            }

            // Reset the falling state
            isFalling = false;
        }
    }
}
