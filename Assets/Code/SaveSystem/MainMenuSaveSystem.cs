using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSaveSystem : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button loadGameButton;
    [SerializeField] private Button backButton;

    [SerializeField] private CurrentSceneManager currentSceneManager;

    public GameObject Self;

    private void Start()
    {
       if (!DataPersistenceManager.instance.HasGameData())
       {
           continueGameButton.interactable = false;
            loadGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        saveSlotsMenu.ActivateMenu(false);
        //Self.SetActive(false);
        this.DeactivateMenu();
        backButton.Select();
    }

    public void OnLoadGameClicked()
    {
        saveSlotsMenu.ActivateMenu(true);
        this.DeactivateMenu();
        backButton.Select();


    }

    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        // load the next scene - which will in turn load the game because of 
        // OnSceneLoaded() in the DataPersistenceManager
       // SceneManager.LoadSceneAsync("HubWorld");

        if(currentSceneManager.CurerntlyInHubWorld == true)
        {
            SceneManager.LoadSceneAsync("HubWorld");

        }

        if (currentSceneManager.CurrentlyInLevel1 == true)
        {
            SceneManager.LoadSceneAsync("Level 1");

        }

        if (currentSceneManager.CurrentlyInLevel2 == true)
        {
            SceneManager.LoadSceneAsync("Level 2");

        }

        if (currentSceneManager.CurrentlyInLevel3 == true)
        {
            SceneManager.LoadSceneAsync("Level 3");

        }


    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }

    public void ActivateMenu()
    {
        Self.SetActive(true);
    }

    public void DeactivateMenu()
    {
       Self.SetActive(false);
    }
}
