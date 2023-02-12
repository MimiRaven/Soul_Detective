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
    public Button Level1Button = null;
    public Button Level2Button = null;
    public Button Level3Button = null;

    public void Start()
    {
        Cursor.visible = true;
    }

    public void MainMenu()
    {
        mainmenuButton.Select();
        audioSource.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void HubWorld()
    {
        SceneManager.LoadScene("HubWorld");
    }

      public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void GamePlayDemo()
    {
        SceneManager.LoadScene("GamePlay Demo");
    }
    public void VerticalSlice()
    {
        SceneManager.LoadScene("IntroCutscene");
    }

    public void ResetGame()
    {
        resetButton.Select();
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioListener.pause = false;
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
        Cursor.visible = false;
    }
}
