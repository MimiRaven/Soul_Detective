using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

  AudioSource audioSource;
  public Button startButton = null;
  public Button ctrlBackButton = null;
  public Button credBackButton = null;
  


  void Start()
  {
    audioSource = GetComponent<AudioSource>();
  
  }
  public void StartGame()
  {
    SceneManager.LoadScene(1);
  }

  public void Quit()
  {
    Application.Quit();
  }

  public void SeeControls()
  {
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(true);
    creditsScreen.SetActive(false);

    ctrlBackButton.Select();
  }

  public void SeeCredits()
  {
    mainMenuScreen.SetActive(false);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(true);

    credBackButton.Select();
  }

  public void GoBack()
  {
    mainMenuScreen.SetActive(true);
    ctrlsScreen.SetActive(false);
    creditsScreen.SetActive(false);

    startButton.Select();
  }

  [SerializeField]
  GameObject mainMenuScreen = null, ctrlsScreen = null, creditsScreen = null;
}
