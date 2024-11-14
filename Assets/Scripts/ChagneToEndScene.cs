using UnityEngine;
using UnityEngine.SceneManagement;  // Required to load scenes

public class LoadEndScene : MonoBehaviour
{
    // Define the target X and Y coordinates to trigger the scene change
    public float targetX = 1.5f;
    public float targetY = 60f;

    void Update()
    {
        // Check if the player's position meets or exceeds the target position
        if (transform.position.x >= targetX && transform.position.y >= targetY)
        {
            // Load the "End" scene
            SceneManager.LoadScene("End");
        }
    }
}
