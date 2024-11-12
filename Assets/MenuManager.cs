using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Pro načítání scén

public class MenuManager : MonoBehaviour
{
    // Funkce pro tlačítko Play
    public void playGame()
    {
        // Nahraď "GameScene" názvem scény, kterou chceš načíst
        SceneManager.LoadScene("MainScene");
    }

    // Funkce pro tlačítko Quit
    public void quitGame()
    {
        // Ukončí hru (funguje pouze v buildnuté verzi, nikoli v editoru)
        Debug.Log("Hra byla ukončena");
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