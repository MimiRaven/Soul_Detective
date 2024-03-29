using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private MainMenuSaveSystem mainMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;

    [SerializeField] private CurrentSceneManager currentSceneManager;
    [SerializeField] private LoadScene LoadManager;

    private SaveSlot[] saveSlots;

    public bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        Cursor.lockState = CursorLockMode.Confined;
        // disable all buttons
        DisableMenuButtons();

        // update the selected profile id to be used for data persistence
        DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());

        if (!isLoadingGame)
        {
            // create a new game - which will initialize our data to a clean slate
         DataPersistenceManager.instance.NewGame();
            StartCoroutine(LoadManager.LoadSceneAsync("Lv1 intro"));

            //if (currentSceneManager.CurerntlyInHubWorld == true)
            //{
            //    SceneManager.LoadSceneAsync("Lv1 intro");
            //
            //}
        }

        // load the scene - which will in turn save the game because of OnSceneUnloaded() in the DataPersistenceManager
        if (currentSceneManager.CurerntlyInHubWorld == true && isLoadingGame)
        {
            //SceneManager.LoadSceneAsync("HubWorld");
            StartCoroutine(LoadManager.LoadSceneAsync("HubWorld"));

        }

        if (currentSceneManager.CurrentlyInLevel1 == true && isLoadingGame)
        {
            //SceneManager.LoadSceneAsync("Level 1");
            StartCoroutine(LoadManager.LoadSceneAsync("Level 1"));

        }

        if (currentSceneManager.CurrentlyInLevel2 == true && isLoadingGame)
        {
            // SceneManager.LoadSceneAsync("Level 2");
            StartCoroutine(LoadManager.LoadSceneAsync("Level 2"));

        }

        if (currentSceneManager.CurrentlyInLevel3 == true && isLoadingGame)
        {
            // SceneManager.LoadSceneAsync("Level 3");
            StartCoroutine(LoadManager.LoadSceneAsync("Level 3"));

        }
    }


    public void OnBackClicked()
    {
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    public void ActivateMenu(bool isLoadingGame)
    {
        this.gameObject.SetActive(true);

        // set mode
        this.isLoadingGame = isLoadingGame;


        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();

        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
            if (profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
              //if (firstSelected.Equals(backButton.gameObject))
              //{
              //    firstSelected = saveSlot.gameObject;
              //}
            }
        }
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }

}
