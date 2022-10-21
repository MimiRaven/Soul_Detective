using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class C_TeleCam : MonoBehaviour
{
    public C_SwitchAimCam c_SwitchAimCam;

    private CinemachineVirtualCamera virtualCamera;
    private int priorityBoostAmount = 11;
    private int priorityMinusAmount = 8;

    void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {

        if(c_SwitchAimCam.GrabObject == true)
        {

            virtualCamera.Priority = priorityBoostAmount;
        }
         
        if(c_SwitchAimCam.ObjectDropped == true)
        {
            virtualCamera.Priority = priorityMinusAmount;
        }

        
    }
}
