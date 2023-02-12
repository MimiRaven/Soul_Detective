using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkilltreeManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction sTreeActivation;

    public GameObject SkillTreeCanvas;

   //public GameObject telekinesis;
   //public GameObject RangeAttack;
   //public GameObject Possesion;

    public GameObject TeleTimer, RangeTimer, PosTimer;

    //public GameObject TeleIcon, RangeIcon, PosIcon;

   //public Button telekinesisButton;
   //public Button RangeAttackButton;
   //public Button PossesionButton;

    public Button TelekinesisTimmerUpgradeButton1;
    public Button TelekinesisTimmerUpgradeButton2;
    public Button TelekinesisTimmerUpgradeButton3;

    public bool TeleTimeUpgrade1;
    public bool TeleTimeUpgrade2;
    public bool TeleTimeUpgrade3;

    public Button RangeAttackTimmerUpgradeButton1;
    public Button RangeAttackTimmerUpgradeButton2;
    public Button RangeAttackTimmerUpgradeButton3;

    public bool RangeAttTimeUpgrade1;
    public bool RangeAttTimeUpgrade2;
    public bool RangeAttTimeUpgrade3;

    public Button PossesionTimmerUpgradeButton1;
    public Button PossesionTimmerUpgradeButton2;
    public Button PossesionTimmerUpgradeButton3;

    public bool PossesionTimeUpgrade1;
    public bool PossesionTimeUpgrade2;
    public bool PossesionTimeUpgrade3;



    public GameObject PlayerWeapon;

    public Button PlayerWeaponUpgradeButton1;
    public Button PlayerWeaponUpgradeButton2;
    public Button PlayerWeaponUpgradeButton3;

    public bool PlayerWeaponUpgrade1;
    public bool PlayerWeaponUpgrade2;
    public bool PlayerWeaponUpgrade3;

    // public Button yourButton;

    public GameObject MainCam;
    public GameObject AimCam;

    public C_PlayerController c_PlayerController;

   // public PlayerAttack playerAttack;

    public bool WheelIsOn;


    public C_TimeManagement c_TimeManagement;

    public C_Telekinesis c_Telekinesis;

    public C_RangeAttack c_RangeAttack;
    public C_Possesion c_Possesion;
    public C_XpScore c_XpScore;


    void Awake()
    {
        sTreeActivation = playerInput.actions["WeaponWheel"];
        //Time.timeScale = 1f;

    }

    void Update()
    {
        if (WheelIsOn == true)
        {
            //c_TimeManagement.TimeStop = true;
            //Time.timeScale = 0f;
            //Cursor.visible = true;
        }
        else
        {
            //c_TimeManagement.TimeStop = false;
            //Time.timeScale = 1f;
           // Cursor.visible = false;
        }
    }

    private void OnEnable()
    {
        sTreeActivation.performed += _ => WheelActiveStart();
        sTreeActivation.canceled += _ => WheelActiveStop();
    }

    private void OnDisable()
    {
        sTreeActivation.performed -= _ => WheelActiveStart();
        sTreeActivation.canceled -= _ => WheelActiveStop();
    }

    void WheelActiveStart()
    {
        if (c_Telekinesis.ObjectGrabbed == false)
        {
            c_TimeManagement.TimeStop = true;
            SkillTreeCanvas.SetActive(true);
            //Time.timeScale = 0f;
            c_PlayerController.WeaponWheel = true;
            MainCam.SetActive(false);
            AimCam.SetActive(false);
            //Cursor.visible = true;

            //playerAttack.IsAbleToAttack = false;

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
        SkillTreeCanvas.SetActive(false);
        //Time.timeScale = 1f;
        c_PlayerController.WeaponWheel = false;
        MainCam.SetActive(true);
        AimCam.SetActive(true);
        //Cursor.visible = false;
       // playerAttack.IsAbleToAttack = true;
        WheelIsOn = false;

        //if (c_PlayerController.Possesed == false)
    }

    //Ability Timers Upgrades

    //Telekinesis Timmer Upgrades
    public void TelekinesisTimmerUpgrade1()
    {
        if(c_XpScore.SkillPoints >= 1)
        {
             TelekinesisTimmerUpgradeButton1.interactable = false;
            c_Telekinesis.SetCoolDownTime -= 1;
            c_XpScore.SkillPoints -= 1;
            TeleTimeUpgrade1 = true;
        }

    }

    public void TelekinesisTimmerUpgrade2()
    {
        if (c_XpScore.SkillPoints >= 2 && TeleTimeUpgrade1 == true)
        {
            TelekinesisTimmerUpgradeButton2.interactable = false;
            c_Telekinesis.SetCoolDownTime -= 1;
            c_XpScore.SkillPoints -= 2;
            TeleTimeUpgrade2= true;
        }
    }

    public void TelekinesisTimmerUpgrade3()
    {
        if (c_XpScore.SkillPoints >= 3 && TeleTimeUpgrade2 == true)
        {
            TelekinesisTimmerUpgradeButton3.interactable = false;
            c_Telekinesis.SetCoolDownTime -= 1;
            c_XpScore.SkillPoints -= 3;
            TeleTimeUpgrade3 = true;

        }
    }

    //Range Attack Timmer Upgrades
    public void RangeAttackTimmerUpgrade1()
    {
        if (c_XpScore.SkillPoints >= 1)
        {
            RangeAttackTimmerUpgradeButton1.interactable = false;
            c_RangeAttack.SetCoolDownTime -= 1;
            c_XpScore.SkillPoints -= 1;
            RangeAttTimeUpgrade1 = true;
        }

    }

    public void RangeAttackTimmerUpgrade2()
    {
        if (c_XpScore.SkillPoints >= 2 && RangeAttTimeUpgrade1 == true)
        {
            RangeAttackTimmerUpgradeButton2.interactable = false;
            c_RangeAttack.SetCoolDownTime -= 1;
            c_XpScore.SkillPoints -= 2;
            RangeAttTimeUpgrade2 = true;
        }
    }

    public void RangeAttackTimmerUpgrade3()
    {
        if (c_XpScore.SkillPoints >= 3 && RangeAttTimeUpgrade2 == true)
        {
            RangeAttackTimmerUpgradeButton3.interactable = false;
            c_RangeAttack.SetCoolDownTime -= 1;
            c_XpScore.SkillPoints -= 3;
            RangeAttTimeUpgrade3 = true;

        }
    }

    //Possesion Timmer Upgrades
    public void PossesionTimmerUpgrade1()
    {
        if (c_XpScore.SkillPoints >= 1)
        {
            PossesionTimmerUpgradeButton1.interactable = false;
            c_Possesion.SetCoolDownTime += 1;
            c_XpScore.SkillPoints -= 1;
            PossesionTimeUpgrade1 = true;
        }

    }

    public void PossesionTimmerUpgrade2()
    {
        if (c_XpScore.SkillPoints >= 2 && PossesionTimeUpgrade1 == true)
        {
            PossesionTimmerUpgradeButton2.interactable = false;
            c_Possesion.SetCoolDownTime += 1;
            c_XpScore.SkillPoints -= 2;
            PossesionTimeUpgrade2 = true;
        }
    }

    public void PossesionTimmerUpgrade3()
    {
        if (c_XpScore.SkillPoints >= 3 && PossesionTimeUpgrade2 == true)
        {
            PossesionTimmerUpgradeButton3.interactable = false;
            c_Possesion.SetCoolDownTime += 1;
            c_XpScore.SkillPoints -= 3;
            PossesionTimeUpgrade3 = true;

        }
    }

    public void WeaponDamadgeUpgrade1()
    {
        if (c_XpScore.SkillPoints >= 1)
        {
            PlayerWeaponUpgradeButton1.interactable = false;
            PlayerWeapon.tag = "WeaponUpgraded1";
            c_XpScore.SkillPoints -= 1;
            PlayerWeaponUpgrade1 = true;
        }
    }

    public void WeaponDamadgeUpgrade2()
    {
        if (c_XpScore.SkillPoints >= 2 && PlayerWeaponUpgrade1 == true)
        {
            PlayerWeaponUpgradeButton2.interactable = false;
            PlayerWeapon.tag = "WeaponUpgraded2";
            c_XpScore.SkillPoints -= 2;
            PlayerWeaponUpgrade2 = true;
        }
    }

    public void WeaponDamadgeUpgrade3()
    {
        if (c_XpScore.SkillPoints >= 3 && PlayerWeaponUpgrade2 == true)
        {
            PlayerWeaponUpgradeButton3.interactable = false;
            PlayerWeapon.tag = "WeaponUpgraded3";
            c_XpScore.SkillPoints -= 3;
            PlayerWeaponUpgrade3 = true;

        }
    }




}