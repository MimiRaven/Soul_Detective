using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraSensitivity : MonoBehaviour
{
    public Slider slider;
    public float mouseSensitivity;
    public Transform playerbody;
    float xRotation = 0f;

    public CinemachineFreeLook cinemachineVirtualCamera;
    private void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", 100);
        slider.value = mouseSensitivity/10;
    }

    void Update()
    {
        PlayerPrefs.SetFloat("currentSensitivity", mouseSensitivity);

        float mouseX = cinemachineVirtualCamera.m_XAxis.m_MaxSpeed = 150f;
        float mouseY = cinemachineVirtualCamera.m_YAxis.m_MaxSpeed = 2f;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    public void AdjustSpeed(float newSpeed)
    {
        mouseSensitivity = newSpeed * 10;
    }
}