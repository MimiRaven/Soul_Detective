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
        XrayCam.SetActive(true);
    }

    void XRayActiveStop()
    {
        XrayCam.SetActive(false);

    }



}
