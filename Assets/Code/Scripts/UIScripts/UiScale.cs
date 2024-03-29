using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiScale : MonoBehaviour
{
    public float FontSize;
    public float scale;

    //lists for ui objects and their scales
    public List<GameObject> gameUIPanels = new List<GameObject>();
    public List<TextMeshProUGUI> gameUITextComponents = new List<TextMeshProUGUI>();
    private List<Button> gameUIButtonComponents = new List<Button>();
    //NPC dialog box text scaling
    public List<GameObject> NPCs = new List<GameObject>();
    public List<TextMeshProUGUI> NPCtext = new List<TextMeshProUGUI>();
    //WIP scaling of objects by multiplication
    public List<GameObject> scalebymultiple = new List<GameObject>();

    public void Awake()
    {
        //gets the scale info from playerprefs
        FontSize = PlayerPrefs.GetFloat("FontSize");
        scale = PlayerPrefs.GetFloat("mutiplescale");

        //grabs all the text objects from the ui objects
        foreach (GameObject panel in gameUIPanels)
        {
            Debug.Log("arin im adding the text object parts");
            TextMeshProUGUI[] tempArray = panel.GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI item in tempArray)
            {
                gameUITextComponents.Add(item);
            }
            Button[] tempButtonArray = panel.GetComponentsInChildren<Button>();
            foreach (Button button in tempButtonArray)
            {
                gameUIButtonComponents.Add(button);
            }
        }
        //grabs the text objects from all the NPCs
        foreach (GameObject panel in NPCs)
        {
            TextMeshProUGUI[] NPCArray = panel.GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI item in NPCArray)
            {
                NPCtext.Add(item);
            }
        }
        //runs a size change
        ChangeFont();
    }

    public void ChangeFont()
    {
        Debug.Log("arin im changing font size");
        FontSize = PlayerPrefs.GetFloat("FontSize");
        //1
        foreach (TextMeshProUGUI textComponent in gameUITextComponents)
        {
            textComponent.fontSize = FontSize;
            Debug.Log("arin the font size should have changed");
        }
        //2
        foreach (Button button in gameUIButtonComponents)
        {
            button.image.rectTransform.sizeDelta = new Vector2((FontSize / 32) * 200, (FontSize / 32) * 50);
        }
        //diag scale
        foreach (TextMeshProUGUI textComponent in NPCtext)
        {
            textComponent.fontSize = textComponent.fontSize * PlayerPrefs.GetFloat("mutiplescale");
        }
        
        
        
        
        //scale by multiply
        /*
        foreach (GameObject gameObject in scalebymultiple) 
        {
            Vector3 scale = new Vector3(1.0f,1,1);
            gameObject.transform.localScale = 
        }*/

    }
}
