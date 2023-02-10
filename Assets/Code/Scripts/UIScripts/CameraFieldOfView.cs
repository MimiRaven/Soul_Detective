using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFieldOfView : MonoBehaviour
{
   public float zoomAmt = 40;

   CinemachineVirtualCamera vcam;

   void Start()
   {
        vcam = GetComponent<CinemachineVirtualCamera>();
   }

   void Update()
   {
        vcam.m_Lens.FieldOfView = zoomAmt;
   }

   public void SliderZoom(float zoom)
   {
        zoomAmt = zoom;
   } 
}