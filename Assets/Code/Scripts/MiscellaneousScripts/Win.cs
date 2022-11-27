using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Button restartButton = null;
    public Button menuButton = null;
    public Button quitButton = null;

    void Start()
    {
        UnlockMouse();
    }

     void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit()
  {
    Application.Quit();
    Debug.Log("Quit");
  }
}
