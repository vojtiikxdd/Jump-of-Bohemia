using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Připoj zde svůj panel menu v Inspectoru
    private bool isPaused = false;

    void Update()
    {
        // Kontrolujeme, zda bylo stisknuto Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Funkce pro pozastavení hry a zobrazení menu
    void PauseGame()
    {
        pauseMenuPanel.SetActive(true); // Zobrazí menu
        Time.timeScale = 0f; // Zastaví čas ve hře (pauza)
        isPaused = true;
    }

    // Funkce pro obnovení hry a skrytí menu
    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false); // Skryje menu
        Time.timeScale = 1f; // Obnoví čas ve hře
        isPaused = false;
    }

    // Funkce pro ukončení hry
    public void QuitGame()
    {
        Application.Quit(); // Ukončí hru (funguje pouze po buildu)
        Debug.Log("Game is exiting...");
    }
}
