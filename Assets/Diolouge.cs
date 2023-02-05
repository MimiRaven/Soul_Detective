using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class Diolouge : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] Lines;
    public float textSpeed;
    public int index;

    [SerializeField]
    private PlayerInput playerInput;


    private InputAction AdvanceDialogue;

    public bool TextEnded;

    // Start is called before the first frame update
    void Start()
    {
       // textComponent.text = string.Empty;
        // StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        AdvanceDialogue = playerInput.actions["Diolouge"];
    }

    private void OnEnable()
    {
        AdvanceDialogue.performed += _ => AdvanceStart();
        AdvanceDialogue.canceled += _ => AdvanceStop();


    }

    private void OnDisable()
    {
        AdvanceDialogue.performed -= _ => AdvanceStart();
        AdvanceDialogue.canceled -= _ => AdvanceStop();


    }

    public void AdvanceStart()
    {
        if (textComponent.text == Lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = Lines[index];
        }

    }

    public void AdvanceStop()
    {

    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        TextEnded = false;
    }

    //public void ResetText()
    //{
    //    if (TextEnded)
    //    {
    //        index= 0;
    //    }
    //}

    IEnumerator TypeLine()
    {
        foreach (char c in Lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

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

            // StartDialogue();
            // gameObject.SetActive(false);
            TextEnded = true;
        }
    }
}
