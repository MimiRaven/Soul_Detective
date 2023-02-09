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
    public bool isPaused;
    public GameObject MainCam;
    public GameObject AimCam;

    public C_TimeManagement c_TimeManagement;
    public C_PlayerController c_PlayerController;
    public C_WeaponWheel c_WeaponWheel;

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
        //Time.timeScale = 0f;
        c_TimeManagement.TimeStop = true;
        MainCam.SetActive(false);
        AimCam.SetActive(false);
        c_PlayerController.WeaponWheel = true;
        AudioListener.pause = true;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        pauseUI.SetActive(true);
        c_WeaponWheel.WheelIsOn = true;
    }

    public void DeactivateMenu()
    {
        //Time.timeScale = 1f;
        c_TimeManagement.TimeStop = false;
        MainCam.SetActive(true);
        AimCam.SetActive(true);
        c_PlayerController.WeaponWheel = false;
        AudioListener.pause = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        pauseUI.SetActive(false);
        //isPaused = false;
        c_WeaponWheel.WheelIsOn = false;
    }

}