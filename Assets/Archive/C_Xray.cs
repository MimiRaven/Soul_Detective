using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class C_Xray : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction XRayActivation;
    public GameObject XrayCam;
    public C_SwitchAimCam c_SwitchAimCam;

    void Awake()
    {
        XRayActivation = playerInput.actions["XRayVision"];
    }

    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
 

    }

    void AimXray()
    {
        if (c_SwitchAimCam.AimOn == false)
        {
            XrayCam.SetActive(true);
        }
    }

    private void OnEnable()
    {
        XRayActivation.performed += _ => XRayActiveStart();
        XRayActivation.canceled += _ => XRayActiveStop();
    }

    private void OnDisable()
    {
        XRayActivation.performed -= _ => XRayActiveStart();
        XRayActivation.canceled -= _ => XRayActiveStop();
    }

    void XRayActiveStart()
    {
        //if (c_SwitchAimCam.AimOn == false)
        //{
        //    XrayCam.SetActive(true);
        //}

        AimXray();

    }

    void XRayActiveStop()
    {
        XrayCam.SetActive(false);

    }



}
