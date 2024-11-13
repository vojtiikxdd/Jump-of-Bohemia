using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneTransition : MonoBehaviour
{
    public float thresholdPercentage = 0.8f;  // Percentage of scene height at which camera moves up
    public float fallThreshold = -5.0f;       // Y-position at which camera moves down
    public Rigidbody2D rb;

    private float nextTopThreshold;
    private float nextBottomThreshold;

    void Start()
    {
        // Calculate the initial scene height and set thresholds
        float sceneHeight = Camera.main.orthographicSize * 2;

        Camera.main.transform.position = new Vector3(0, 0, -10);
    }

    void Update()
    {
        // Get player's current position
        float playerYPosition = transform.position.y;

        // Calculate the current top and bottom visible bounds of the camera
        float cameraTopBound = Camera.main.transform.position.y + Camera.main.orthographicSize;
        float cameraBottomBound = Camera.main.transform.position.y - Camera.main.orthographicSize;

        // Check if player has reached the top threshold (scene upgrade)
        if (playerYPosition >= cameraTopBound)
        {
            // Move the camera up and set a new threshold for next upgrade
            Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y + 10, -10);
        }

        // Check if player has fallen below the fall threshold (scene downgrade)
        if (playerYPosition <= cameraBottomBound)// && rb.velocity.y < 0)
        {
            // Move the camera down and set a new threshold for next downgrade
            Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y - 10, -10);
        }
    }
}
