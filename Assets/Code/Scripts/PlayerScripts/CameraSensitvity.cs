using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSensitvity : MonoBehaviour
{
    //sets up public vars for the rotation speeds for in engine ease of changing the levels to test what max/min should be
    public float hsense;
    public float vsense;
    
    public CinemachineVirtualCamera vcam;
    
    //only runs on the scene load since theres no way to change sensitivity in-level 
    void Start()
    {
        hsense = PlayerPrefs.GetFloat("Hsensitvity");
        vsense = PlayerPrefs.GetFloat("Vsensitvity");
        vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = hsense;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = vsense;
    }
}
