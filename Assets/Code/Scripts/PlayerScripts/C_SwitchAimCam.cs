using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class C_SwitchAimCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int priorityBoostAmount = 10;

    public GameObject aimCanvas;
    public bool AimOn;
    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;

    public GameObject XrayCam;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"]; 
    }


    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        AimOn = true;
        virtualCamera.Priority += priorityBoostAmount;
        aimCanvas.SetActive(true);
        XrayCam.SetActive(false);
    }
    private void CancelAim()
    {
        AimOn = false;
        virtualCamera.Priority -= priorityBoostAmount;
        aimCanvas.SetActive(false);

    }

}
