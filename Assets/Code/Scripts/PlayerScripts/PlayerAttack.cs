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
            animator.SetTrigger("Melee0");
            //audioSource.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            //audioSource.PlayOneShot(audioSource.clip);
        }
    }
}