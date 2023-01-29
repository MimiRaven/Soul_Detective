using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_WeaponSelect : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;


    private InputAction RangeAttackActive;
    private InputAction TelekinisisActive;
    private InputAction PossesionActive;

    public GameObject telekinesis;
    public GameObject RangeAttack;
    public GameObject Possesion;

    public GameObject TeleTimer, RangeTimer, PosTimer;

    public GameObject TeleIcon, RangeIcon, PosIcon;
    // Start is called before the first frame update
   //void Start()
   //{
   //    RangeAttackActive = playerInput.actions["RangeAttackActivation"];
   //    TelekinisisActive = playerInput.actions["TelekinisisAttackActivation"];
   //    PossesionActive = playerInput.actions["PossesionAttackActivation"];
   //}

    void Awake()
    {
        RangeAttackActive = playerInput.actions["RangeAttackActivation"];
        TelekinisisActive = playerInput.actions["TelekinisisAttackActivation"];
        PossesionActive = playerInput.actions["PossesionAttackActivation"];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        RangeAttackActive.performed += _ => RangeAttackStart();
        RangeAttackActive.canceled += _ => RangeAttackStop();

        TelekinisisActive.performed += _ => TelekinisisStart();
        TelekinisisActive.canceled += _ => TelekinisisStop();

        PossesionActive.performed += _ => PossesionStart();
        PossesionActive.canceled += _ => PossesionStop();
    }

    private void OnDisable()
    {
        RangeAttackActive.performed -= _ => RangeAttackStart();
        RangeAttackActive.canceled -= _ => RangeAttackStop();

        TelekinisisActive.performed -= _ => TelekinisisStart();
        TelekinisisActive.canceled -= _ => TelekinisisStop();

        PossesionActive.performed -= _ => PossesionStart();
        PossesionActive.canceled -= _ => PossesionStop();
    }

    void RangeAttackStart()
    {
        Debug.Log("RangeButtonPressed");
        telekinesis.SetActive(false);
        RangeAttack.SetActive(true);
        Possesion.SetActive(false);

        RangeIcon.SetActive(true);
        TeleIcon.SetActive(false);
        PosIcon.SetActive(false);

        TeleTimer.SetActive(false);
        PosTimer.SetActive(false);
    }
    void RangeAttackStop()
    {

    }

    void TelekinisisStart()
    {
        telekinesis.SetActive(true);
        RangeAttack.SetActive(false);
        Possesion.SetActive(false);

        RangeIcon.SetActive(false);
        TeleIcon.SetActive(true);
        PosIcon.SetActive(false);

        PosTimer.SetActive(false);
        RangeTimer.SetActive(false);
    }
    void TelekinisisStop()
    {

    }

    void PossesionStart()
    {
        telekinesis.SetActive(false);
        RangeAttack.SetActive(false);
        Possesion.SetActive(true);

        RangeIcon.SetActive(false);
        TeleIcon.SetActive(false);
        PosIcon.SetActive(true);

        RangeTimer.SetActive(false);
        TeleTimer.SetActive(false);
    }
    void PossesionStop()
    {

    }
}
