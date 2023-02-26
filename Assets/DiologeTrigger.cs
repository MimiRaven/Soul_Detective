using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiologeTrigger : MonoBehaviour
{
    public Diolouge diologe;

    public bool PlayerINrange;

    public bool DiologeStarted;

    public GameObject NPCdiologeBox;

    [SerializeField]
    private PlayerInput playerInput;


    private InputAction AdvanceDialogue;

    public AudioSource audioSource;

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
        if (PlayerINrange == true & diologe.TextEnded == false)
        {
            DiologeStarted = true;
            NPCdiologeBox.SetActive(true);
            //diologe.StartDialogue();
            diologe.TextEnded = false;
            //ResetT();
            
        }

    }

    public void AdvanceStop()
    {

    }

    public void ResetT()
    {
        if (diologe.TextEnded == true)
        {
            //diologe.StartDialogue();
            diologe.index = 0;
            NPCdiologeBox.SetActive(false);
            diologe.TextEnded = false;
            //audioSource.Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        NPCdiologeBox.SetActive(false);
        diologe.index = 0;
    }

    // Update is called once per frame
    void Update()
    {

        ResetT();

        if (DiologeStarted == true)
        {
            //diologe.StartDialogue();
            
        }

        if(diologe.index == 0 && DiologeStarted)
        {
            audioSource.Play();
        }
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            PlayerINrange = true;
            diologe.index = 0;
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
        {
            PlayerINrange = false;
            diologe.index = 0;
            NPCdiologeBox.SetActive(false);

        }
    }

}
