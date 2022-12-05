using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class C_PauseManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public AudioSource audioSource;

    public Button resumeButton = null;
    public Button mainmenuButton = null;
    public Button resetButton = null;
    public Button quitButton = null;

    public void MainMenu()
    {
        mainmenuButton.Select();
        audioSource.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void ResetGame()
    {
        resetButton.Select();
        audioSource.Play();
        SceneManager.LoadScene("Vertical Slice Level");
    }

    public void Quit()
    {
        quitButton.Select();
        audioSource.Play();
        Application.Quit();
    }

    public void Resume()
    {
        resumeButton.Select();
        audioSource.Play();
        pauseMenu.isPaused = false;
        pauseMenu.DeactivateMenu();
    }
}
