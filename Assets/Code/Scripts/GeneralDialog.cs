using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class GeneralDialog : MonoBehaviour
{
    /// trigger reference section
    public int subIndex; //manually input the number for each 
    public AudioSource soundobject;
    public float NewLineDelay;
    public float EndOfTextDelay;

    // scrolling text reference section
    public TextMeshProUGUI textComponent;
    public string[] Lines;
    public float textSpeed;
    public int index;
    public bool TextEnded;


    /// <summary>
    /// delete the void start (its temp to make sure that the index is always starting at 0
    /// </summary>

    void Start()
    {
        PlayerPrefs.SetInt("subIndexPosition", 0);
    }

    /// <summary>
    /// delete the void start
    /// </summary>




    //when the player enters the trigger box
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("arin the player ran thorough");
            if (PlayerPrefs.GetInt("subIndexPosition") == subIndex)
            {
                //sound plays
                soundobject.volume = PlayerPrefs.GetFloat("diagvolpref");
                soundobject.Play();
                //updates the index of dialog, and runs the text
                PlayerPrefs.SetInt("subIndexPosition", subIndex + 1);
                StartDialogue();
            }
        }

    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        TextEnded = false;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in Lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            //StartCoroutine(uitimer());
            //NextLine();
        }
        StartCoroutine(linedelay());

    }
    //method for scrolling to next line
    void NextLine()
    {
        if (index < Lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            TextEnded = true;
            StartCoroutine(hideeverything());
        }
    }
    //coroutine to run next line after couple of seconds
    IEnumerator linedelay()
    {
        yield return new WaitForSeconds(NewLineDelay);
        //UIcanvas.SetActive(false);
        NextLine();
    }
    //coroutine to run after all lines have been shown
    IEnumerator hideeverything()
    {
        yield return new WaitForSeconds(EndOfTextDelay);
        textComponent.text = string.Empty;
    }
}
