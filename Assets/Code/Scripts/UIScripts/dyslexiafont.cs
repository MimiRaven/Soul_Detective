using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dyslexiafont : MonoBehaviour
{
    //public Toggle SettingsToggle;
    //fonts to use
    public TMP_FontAsset OrginialFont;
    public TMP_FontAsset DyslexiaFont;

    //lists of objects with fonts
    public List<GameObject> Objects = new List<GameObject>();
    public List<TextMeshProUGUI> ObjectText = new List<TextMeshProUGUI>();

    void Awake()
    {
        //generating list with text items
        foreach (GameObject panel in Objects)
        {
            TextMeshProUGUI[] textobjarray = panel.GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI item in textobjarray)
            {
                ObjectText.Add(item);
            }
        }
        FontStyleChange();
    }

    //changing the fonts
    public void FontStyleChange()
    {
        foreach(TextMeshProUGUI textComponent in ObjectText)
        {
            //starting on regular going to dyslexia
            if (PlayerPrefs.GetInt("CurrentFont") == 0) 
            {
                //textComponent.font = DyslexiaFont;
                PlayerPrefs.SetInt("CurrentFont", 1);
                Debug.Log("arin, going to dyslexia 1st");
            }
            //starting on dyslexia to regular
            else if (PlayerPrefs.GetInt("CurrentFont") == 1)
            {
                //textComponent.font = OrginialFont;
                PlayerPrefs.SetInt("CurrentFont", 0);
                Debug.Log("arin, going to normal 2nd");
            }
        }
    }
}
