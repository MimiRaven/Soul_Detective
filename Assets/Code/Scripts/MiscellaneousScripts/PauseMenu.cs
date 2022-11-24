using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    private PlayerControls playerContols;
    private InputAction menu;

    [SerializeField]
    private GameObject pauseUI;

    [SerializeField]
    private bool isPaused;
  
    void Awake()
    {
        playerContols = new PlayerControls();
    }

    void Update()
    {
        
    }


    private void OnEnable()
    {
        menu = playerContols.Menu.Pause;
        menu.Enable();

        menu.performed += Pause;

    }

    private void OnDisable()
    {

        playerContols.Disable();
    }

    void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }
    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseUI.SetActive(false);
        isPaused = false;
    }

}