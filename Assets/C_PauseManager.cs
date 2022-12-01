using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_PauseManager : MonoBehaviour
{
    public PauseMenu pauseMenu;

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("GamePlay Demo");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        pauseMenu.isPaused = false;
        pauseMenu.DeactivateMenu();
    }
}
