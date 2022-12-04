using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_PauseManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public AudioSource audioSource;

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        audioSource.Play();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Vertical Slice Level");
        audioSource.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        audioSource.Play();
        pauseMenu.isPaused = false;
        pauseMenu.DeactivateMenu();
    }
}
