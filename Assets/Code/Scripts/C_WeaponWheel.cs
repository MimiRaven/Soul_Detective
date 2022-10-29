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
        Time.timeScale = 0.5f;
        Cursor.visible = true;
    }

    void WheelActiveStop()
    {
        WheelCanvas.SetActive(false);
        Time.timeScale = 1f;
        //Cursor.visible = false;
    }

    public void TelekinesisActive()
    {
        telekinesis.SetActive(true);
        RangeAttack.SetActive(false);
        Possesion.SetActive(false);
    }

    public void RangeAttackActive()
    {
        RangeAttack.SetActive(true);
        telekinesis.SetActive(false);
        Possesion.SetActive(false);
    }

    public void PossesionActive()
    {
        Possesion.SetActive(true);
        RangeAttack.SetActive(false);
        telekinesis.SetActive(false);
    }
}
