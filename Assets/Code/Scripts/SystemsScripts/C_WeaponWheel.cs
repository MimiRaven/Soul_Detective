using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_WeaponWheel : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction WheelActivation;

    public GameObject WheelCanvas;

    public GameObject telekinesis;
    public GameObject RangeAttack;
    public GameObject Possesion;

    public GameObject telekinesisButton;
    public GameObject RangeAttackButton;
    public GameObject PossesionButton;

    public GameObject MainCam;
    public GameObject AimCam;

    public C_PlayerController c_PlayerController;

    public PlayerAttack playerAttack;

    


    void Awake()
    {
        WheelActivation = playerInput.actions["WeaponWheel"];
        Time.timeScale = 1f;

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
        WheelCanvas.SetActive(true);
        Time.timeScale = 0f;
        c_PlayerController.WeaponWheel = true;
        MainCam.SetActive(false);
        AimCam.SetActive(false);
        Cursor.visible = true;
        playerAttack.IsAbleToAttack = false;

        //if(c_PlayerController.Possesed == false)
        //{
        //    Time.timeScale = 0f;
        //    Cursor.visible = true;
        //}

    }

    void WheelActiveStop()
    {
        WheelCanvas.SetActive(false);
        Time.timeScale = 1f;
        c_PlayerController.WeaponWheel = false;
        MainCam.SetActive(true);
        AimCam.SetActive(true);
        Cursor.visible = false;
        playerAttack.IsAbleToAttack = true;

        //if (c_PlayerController.Possesed == false)
    }

    public void TelekinesisActive()
    {
        telekinesis.SetActive(true);
        RangeAttack.SetActive(false);
        Possesion.SetActive(false);

        telekinesisButton.SetActive(false);
        RangeAttackButton.SetActive(true);
        PossesionButton.SetActive(true);
    }

    public void RangeAttackActive()
    {
        RangeAttack.SetActive(true);
        telekinesis.SetActive(false);
        Possesion.SetActive(false);

        RangeAttackButton.SetActive(false);
        telekinesisButton.SetActive(true);
        PossesionButton.SetActive(true);
    }

    public void PossesionActive()
    {
        Possesion.SetActive(true);
        RangeAttack.SetActive(false);
        telekinesis.SetActive(false);

        PossesionButton.SetActive(false);
        RangeAttackButton.SetActive(true);
        telekinesisButton.SetActive(true);
    }
}
