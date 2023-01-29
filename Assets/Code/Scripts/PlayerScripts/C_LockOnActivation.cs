using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class C_LockOnActivation : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction LockOnActivation;
    public GameObject LockOnCam;
    public bool LockonBool;

    public C_CameraTarget LockOnCamScript;
    public C_LocOnRange LockRangeScript;
    public C_Telekinesis c_Telekinesis;

    public GameObject LockOnCanvas;
    public TextMeshProUGUI LockOnUI;

    void Awake()
    {
        LockOnActivation = playerInput.actions["LockOn"];
        Time.timeScale = 1f;

    }

    public void Update()
    {
        if (c_Telekinesis.ObjectGrabbed == true)
        {
            LockonBool = false;
        }

        if (LockRangeScript.EnemyInRange == true)
        {
            LockOnCanvas.SetActive(true);

           if (LockonBool)
           {
                LockOnUI.text = "LockOn:Enabled";
               LockOnCam.SetActive(true);
               LockOnCamScript.enemyContact = true;
           }
           else 
           {
                LockOnUI.text = "LockOn:Disabled";
               LockOnCam.SetActive(false);
               LockOnCamScript.enemyContact = false;
               LockOnCamScript.ClosestEnemyFound = false;
           }

        }
        else
        {
            LockonBool = false;
            LockOnCanvas.SetActive(false);
            LockOnCam.SetActive(false);
            LockOnCamScript.enemyContact = false;
            LockOnCamScript.ClosestEnemyFound = false;
        }
    }

    private void OnEnable()
    {
        LockOnActivation.performed += _ => LockOnStart();
        LockOnActivation.canceled += _ => LockOnEnd();
    }

    private void OnDisable()
    {
        LockOnActivation.performed -= _ => LockOnStart();
        LockOnActivation.canceled -= _ => LockOnEnd();
    }

    public void LockOnStart()
    {

        if (LockRangeScript.EnemyInRange == true)
        {
            LockonBool = !LockonBool;

        }

        

    }

    public void LockOnEnd()
    {

    }
}
