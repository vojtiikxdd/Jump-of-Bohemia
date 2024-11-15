using UnityEngine;

public class PlayerSoundJump : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Reference to AudioSource
    [SerializeField] private AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayJumpSound()
    {
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound); // Play the sound
        }
    }
}
