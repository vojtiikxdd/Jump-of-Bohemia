using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void PlayGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public GameObject settingsPanel; // Panel s nastavením

    // Funkce pro otevření nastavení
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    // Funkce pro zavření nastavení
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
    