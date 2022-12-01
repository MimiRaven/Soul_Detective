using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private PlayerInput playerInput;

    private InputAction AttackAction;

    public bool IsAbleToAttack;

    AudioSource audioSource;
    public AudioClip[] audioClipArray;

    public void Awake()
    {
        AttackAction = playerInput.actions["Attack"];
    }

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        IsAbleToAttack = true;
    }

    public void Update()
    {

    }

    private void OnEnable()
    {
        
        AttackAction.performed += _ => AttackStart();
        AttackAction.canceled += _ => AttackStop();

    }

    private void OnDisable()
    {

        AttackAction.performed -= _ => AttackStart();
        AttackAction.canceled -= _ => AttackStop();

    }

    public void AttackStart()
    {
        Attacking();
    }

    public void AttackStop()
    {

    }

    public void Attacking()
    {
        if(IsAbleToAttack == true)
        {
            animator.SetBool("Ideling", false);
            animator.SetBool("Melee", true);
            //audioSource.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            //audioSource.PlayOneShot(audioSource.clip);
        }
        else
        {
            animator.SetBool("Melee", false);
            animator.SetBool("Ideling", true);
        }
    }
}