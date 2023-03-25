using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

  public AudioSource audioSource;
 // public Button startGameSaveSystemButton = null;
  public Button startButton = null;
  public Button levelBackButton = null;
  public Button settingsBackButton = null;
  public Button accessBackButton = null;
  public Button KMBackButton = null;
  public Button conBackButton = null;
  public Button ctrlBackButton = null;
  public Button credBackButton = null;
  public Button SaveSystemBackButton = null;

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

    public void SeePlayMenu()
    {
        PlayGameSaveSystemScreen.SetActive(true);
        levelsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(false);
        accessibilitiesScreen.SetActive(false);
        ctrlsScreen.SetActive(false);
        kmScreen.SetActive(false);
        controllerScreen.SetActive(false);
        creditsScreen.SetActive(false);

        SaveSystemBackButton.Select();
        audioSource.Play();
    }

    public void SeeLevels()
    {
        
        levelsScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(false);
        accessibilitiesScreen.SetActive(false);
        ctrlsScreen.SetActive(false);
        kmScreen.SetActive(false);
        controllerScreen.SetActive(false);
        creditsScreen.SetActive(false);
        PlayGameSaveSystemScreen.SetActive(false);

        levelBackButton.Select();
        audioSource.Play();
    }

    public void SeeSettings()
    {
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(true);
        accessibilitiesScreen.SetActive(false);
        ctrlsScreen.SetActive(false);
        kmScreen.SetActive(false);
        controllerScreen.SetActive(false);
        creditsScreen.SetActive(false);
        levelsScreen.SetActive(false);
        PlayGameSaveSystemScreen.SetActive(false);

        settingsBackButton.Select();
        audioSource.Play();
    }

    public void SeeAccessibilities()
    {
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(false);
        accessibilitiesScreen.SetActive(true);
        ctrlsScreen.SetActive(false);
        kmScreen.SetActive(false);
        controllerScreen.SetActive(false);
        creditsScreen.SetActive(false);
        levelsScreen.SetActive(false);
        PlayGameSaveSystemScreen.SetActive(false);

        accessBackButton.Select();
        audioSource.Play();
    }

    public void SeeControls()
  {
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(true);
    settingsScreen.SetActive(false);
    accessibilitiesScreen.SetActive(false);
    kmScreen.SetActive(false);
    controllerScreen.SetActive(false);
    creditsScreen.SetActive(false);
    levelsScreen.SetActive(false);
    PlayGameSaveSystemScreen.SetActive(false);

    ctrlBackButton.Select();
    audioSource.Play();
  }

    public void SeeKM()
    {
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(false);
        accessibilitiesScreen.SetActive(false);
        ctrlsScreen.SetActive(false);
        kmScreen.SetActive(true);
        controllerScreen.SetActive(false);
        creditsScreen.SetActive(false);
        levelsScreen.SetActive(false);
        PlayGameSaveSystemScreen.SetActive(false);

        KMBackButton.Select();
        audioSource.Play();
    }

    public void SeeController()
    {
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(false);
        accessibilitiesScreen.SetActive(false);
        ctrlsScreen.SetActive(false);
        kmScreen.SetActive(false);
        controllerScreen.SetActive(true);
        creditsScreen.SetActive(false);
        levelsScreen.SetActive(false);
        PlayGameSaveSystemScreen.SetActive(false);

        conBackButton.Select();
        audioSource.Play();
    }

    public void SeeCredits()
  {
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(false);
    settingsScreen.SetActive(false);
    accessibilitiesScreen.SetActive(false);
    kmScreen.SetActive(false);
    controllerScreen.SetActive(false);
    creditsScreen.SetActive(true);
    levelsScreen.SetActive(false);
    PlayGameSaveSystemScreen.SetActive(false);

    credBackButton.Select();
    audioSource.Play();
  }

  public void GoBack()
  {
    mainMenuScreen.SetActive(true);
    settingsScreen.SetActive(false);
    accessibilitiesScreen.SetActive(false);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(false);
    kmScreen.SetActive(false);
    controllerScreen.SetActive(false);
    levelsScreen.SetActive(false);
    PlayGameSaveSystemScreen.SetActive(false);

    startButton.Select();
    audioSource.Play();
  }

    [SerializeField]
    GameObject mainMenuScreen = null, settingsScreen = null, accessibilitiesScreen = null, ctrlsScreen = null, kmScreen = null, controllerScreen = null, creditsScreen = null, levelsScreen = null, PlayGameSaveSystemScreen = null;
}
