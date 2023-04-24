using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontWarning : MonoBehaviour
{
    //warning when highlighted
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("arin warning");
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("end arin warning");
    }
    private void OnMouseEnter()
    {
        Debug.Log("arin warning");
    }
}
