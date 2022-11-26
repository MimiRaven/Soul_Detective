using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    public Button checkButton = null;
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

    public void RetryCheckpoint()
    {
      
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
  {
    Application.Quit();
    Debug.Log("Quit");
  }
}