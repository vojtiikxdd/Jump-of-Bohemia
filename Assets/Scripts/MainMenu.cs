using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void GameMenu()
    {
         scenemanagement.LoadScene(scenemanager.GetActiveScene().buildIndex + 1);
    }

    private void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
    