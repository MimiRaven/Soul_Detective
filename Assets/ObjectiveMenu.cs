using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectiveMenu : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction WheelActivation;

    public GameObject ObjectiveCanvas;



    public GameObject MainCam;
    public GameObject AimCam;

    public C_PlayerController c_PlayerController;

    public PlayerAttack playerAttack;

    public bool ObjectiveMenuOn;

    public C_Telekinesis c_Telekinesis;

    public C_TimeManagement c_TimeManagement;
    
    public bool WheelIsOn;



    void Awake()
    {
        WheelActivation = playerInput.actions["ObjectiveMenu"];
        //Time.timeScale = 1f;

    }

    void Update()
    {
        if (ObjectiveMenuOn == true)
        {
            //c_TimeManagement.TimeStop = true;
            //Time.timeScale = 0f;
            Cursor.visible = true;
        }
        else
        {
            //c_TimeManagement.TimeStop = false;
            //Time.timeScale = 1f;
            Cursor.visible = false;
        }
    }

    private void OnEnable()
    {
        WheelActivation.performed += _ => WheelActiveStart();
        WheelActivation.canceled += _ => WheelActiveStop();
    }

    private void OnDisable()
    {
        WheelActivation.performed -= _ => WheelActiveStart();
        WheelActivation.canceled -= _ => WheelActiveStop();
    }

    void WheelActiveStart()
    {
        if (c_Telekinesis.ObjectGrabbed == false)
        {
            WheelIsOn = !WheelIsOn;

            if (WheelIsOn)
            {
                MenuActive();
            }
            else
            {
                MenuDeactive();
            }


        }

    }

    void WheelActiveStop()
    {

    }

    void MenuActive()
    {
        if (c_Telekinesis.ObjectGrabbed == false)
        {
            WheelIsOn = true;
            c_TimeManagement.TimeStop = true;
            ObjectiveCanvas.SetActive(true);
            //Time.timeScale = 0f;
            c_PlayerController.WeaponWheel = true;
            MainCam.SetActive(false);
            AimCam.SetActive(false);
            //Cursor.visible = true;

            playerAttack.IsAbleToAttack = false;

            ObjectiveMenuOn = true;

            //if(c_PlayerController.Possesed == false)
            //{
            //    Time.timeScale = 0f;
            //    Cursor.visible = true;
            //}


        }
    } 

    void MenuDeactive()
    {
        WheelIsOn= false;
        c_TimeManagement.TimeStop = false;
        ObjectiveCanvas.SetActive(false);
        //Time.timeScale = 1f;
        c_PlayerController.WeaponWheel = false;
        MainCam.SetActive(true);
        AimCam.SetActive(true);
        //Cursor.visible = false;
        playerAttack.IsAbleToAttack = true;
        ObjectiveMenuOn = false;

        //if (c_PlayerController.Possesed == false)
    }

   

}



