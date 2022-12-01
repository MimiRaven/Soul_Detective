using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class C_WeaponWheel : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction WheelActivation;

    public GameObject WheelCanvas;

    public GameObject telekinesis;
    public GameObject RangeAttack;
    public GameObject Possesion;

    public GameObject TeleTimer, RangeTimer, PosTimer;

    public Button telekinesisButton;
    public Button RangeAttackButton;
    public Button PossesionButton;
   // public Button yourButton;

    public GameObject MainCam;
    public GameObject AimCam;

    public C_PlayerController c_PlayerController;

    public PlayerAttack playerAttack;

    public bool WheelIsOn;

    public C_Telekinesis c_Telekinesis;

    public C_TimeManagement c_TimeManagement;



    void Awake()
    {
        WheelActivation = playerInput.actions["WeaponWheel"];
        //Time.timeScale = 1f;

    }

    void Update()
    {
        if(WheelIsOn == true)
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
        if(c_Telekinesis.ObjectGrabbed == false)
        {
            c_TimeManagement.TimeStop = true;
            WheelCanvas.SetActive(true);
         //Time.timeScale = 0f;
         c_PlayerController.WeaponWheel = true;
         MainCam.SetActive(false);
         AimCam.SetActive(false);
         //Cursor.visible = true;
         playerAttack.IsAbleToAttack = false;
         WheelIsOn = true;

         //if(c_PlayerController.Possesed == false)
         //{
         //    Time.timeScale = 0f;
         //    Cursor.visible = true;
         //}


        }

    }

    void WheelActiveStop()
    {
        c_TimeManagement.TimeStop = false;
        WheelCanvas.SetActive(false);
        //Time.timeScale = 1f;
        c_PlayerController.WeaponWheel = false;
        MainCam.SetActive(true);
        AimCam.SetActive(true);
        //Cursor.visible = false;
        playerAttack.IsAbleToAttack = true;
        WheelIsOn = false;

        //if (c_PlayerController.Possesed == false)
    }

    public void TelekinesisActive()
    {
        telekinesis.SetActive(true);
        RangeAttack.SetActive(false);
        Possesion.SetActive(false);
    
       telekinesisButton.interactable = false;
       RangeAttackButton.interactable = true;
       PossesionButton.interactable = true;
        PosTimer.SetActive(false);
        RangeTimer.SetActive(false);
    }

    public void RangeAttackActive()
    {
        RangeAttack.SetActive(true);
        telekinesis.SetActive(false);
        Possesion.SetActive(false);
    
        RangeAttackButton.interactable = false;
        telekinesisButton.interactable = true;
        PossesionButton.interactable = true;

        TeleTimer.SetActive(false);
        PosTimer.SetActive(false);
    }
    
    public void PossesionActive()
    {
        Possesion.SetActive(true);
        RangeAttack.SetActive(false);
        telekinesis.SetActive(false);
    
        PossesionButton.interactable = false;
        RangeAttackButton.interactable = true;
        telekinesisButton.interactable = true;

        RangeTimer.SetActive(false);
        TeleTimer.SetActive(false);
        
    }
}
