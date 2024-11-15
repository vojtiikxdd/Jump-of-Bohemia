using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureFadeSequenceNoCoroutine : MonoBehaviour
{
    public CanvasGroup firstImage;
    public CanvasGroup secondImage;
    public float fadeDuration = 4.0f;

    private int currentState = 0;
    private float fadeTimer = 0f;
    private bool isWaitingForInput = false;

    public GameObject Quote;
    public GameObject TheEnd;

    public float incrementAmount = 1.0f;
    public bool End = false;

    private void Update()
    {
        if (isWaitingForInput)
        {
            // Wait for any key press to show the third image
            if (Input.anyKeyDown)
            {
                currentState = 5; // Move to third image fade-in state
                fadeTimer = 0f;
                isWaitingForInput = false;
            }
            return;
        }

        // Manage fade states
        fadeTimer += Time.deltaTime;
        float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);

        switch (currentState)
        {
            case 0: // Fade in first image
                firstImage.alpha = alpha;
                if (fadeTimer >= fadeDuration) { TransitionToNextState(); }
                break;
            case 1: // Fade out first image
                firstImage.alpha = 1 - alpha;
                if (fadeTimer >= fadeDuration) 
                { 
                    TransitionToNextState(); 
                    Vector3 newPosition = Quote.transform.position;
                    newPosition.z += incrementAmount;
                    Quote.transform.position = newPosition;
                    Vector3 newwPosition = TheEnd.transform.position;
                    newPosition.z -= incrementAmount;
                    TheEnd.transform.position = newwPosition;
                    End = true;
                }
                break;
        }
        if (End)
        {
            // Wait for button press after the second image fades out
            isWaitingForInput = true;
            if(Input.GetKey( KeyCode.Space )) SceneManager.LoadScene("Menu");
        }
    }

    private void TransitionToNextState()
    {
        fadeTimer = 0f;
        currentState++;
    }
}