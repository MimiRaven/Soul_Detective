using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_UIxpBar : MonoBehaviour
{
   public static C_UIxpBar instance { get; private set; }
   
   public Image mask;
   float originalSize;
   
   void Awake()
   {
       instance = this;
   }
   
   void Start()
   {
       originalSize = mask.rectTransform.rect.width;
   }
   
   public void SetValue(float value)
   {
       mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
   }
}
