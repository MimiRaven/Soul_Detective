using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_LockOnActivation : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction LockOnActivation;
    public GameObject LockOnCam;
    public bool LockonBool;

    public C_CameraTarget LockOnCamScript;
    public C_LocOnRange LockRangeScript;

    void Awake()
    {
        LockOnActivation = playerInput.actions["LockOn"];
        Time.timeScale = 1f;

    }

    public void Update()
    {
        if (LockRangeScript.EnemyInRange == true)
        {
           if (LockonBool)
           {
               LockOnCam.SetActive(true);
               LockOnCamScript.enemyContact = true;
           }
           else 
           { 
               LockOnCam.SetActive(false);
               LockOnCamScript.enemyContact = false;
           }

        }
        else
        {
            LockOnCam.SetActive(false);
            LockOnCamScript.enemyContact = false;
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
        LockonBool = !LockonBool;

    }

    public void LockOnEnd()
    {

    }
}
