using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

  public AudioSource audioSource;
  public Button startButton = null;
  public Button ctrlBackButton = null;
  public Button credBackButton = null;
  public Button quitButton = null;
  public Button Level1Button = null;
  public Button Level2Button = null;
  public Button Level3Button = null;
  

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
        UnlockMouse();
    audioSource.Stop();
  }
  public void StartGame()
  {
    SceneManager.LoadScene("IntroCutscene"); 
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

    public void Quit()
  {
        quitButton.Select();
        audioSource.Play();
        Application.Quit();
  }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SeeLevels()
    {
        levelsScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
        ctrlsScreen.SetActive(false);
        creditsScreen.SetActive(false);

        ctrlBackButton.Select();
        audioSource.Play();
    }
  public void SeeControls()
  {
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(true);
    creditsScreen.SetActive(false);
        levelsScreen.SetActive(false);

        ctrlBackButton.Select();
    audioSource.Play();
  }

  public void SeeCredits()
  {
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(true);
        levelsScreen.SetActive(false);

        credBackButton.Select();
    audioSource.Play();
  }

  public void GoBack()
  {
    mainMenuScreen.SetActive(true);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(false);
        levelsScreen.SetActive(false);

        startButton.Select();
    audioSource.Play();
  }

  [SerializeField]
  GameObject mainMenuScreen = null, ctrlsScreen = null, creditsScreen = null, levelsScreen = null;
}
