using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneTransition : MonoBehaviour
{
    private Camera mainCamera;

    // Reference to the player's Rigidbody2D
    private Rigidbody2D rb;

    public float thresholdPercentage = 0.5f; // When the player reaches 50% of scene height
    public float fallThreshold = -5f; // When the player falls below this Y value

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Calculate the scene height in world space
        float sceneHeight = mainCamera.orthographicSize * 2;

        // Get player's current position
        float playerYPosition = transform.position.y;

        // Check if player has reached the top threshold (scene upgrade)
        if (playerYPosition >= sceneHeight * thresholdPercentage)
        {
            // Load next scene (index + 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // Check if player has fallen below the fall threshold (scene downgrade)
        if (playerYPosition <= fallThreshold && rb.velocity.y < 0)
        {
            // Load previous scene (index - 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
