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

  public void SeeControls()
  {
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(true);
    creditsScreen.SetActive(false);

    ctrlBackButton.Select();
    audioSource.Play();
  }

  public void SeeCredits()
  {
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(true);

    credBackButton.Select();
    audioSource.Play();
  }

  public void GoBack()
  {
    mainMenuScreen.SetActive(true);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(false);

    startButton.Select();
    audioSource.Play();
  }

  [SerializeField]
  GameObject mainMenuScreen = null, ctrlsScreen = null, creditsScreen = null;
}
