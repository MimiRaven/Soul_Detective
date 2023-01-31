using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_PossesedEnemyAttack : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    public PlayerInput playerInput;

    private InputAction AttackAction;

    public bool isAttacking;

    public GameObject RightHand, LeftHand;

    AudioSource audioSource;
    public AudioClip[] audioClipArray;

    [SerializeField]
    private float animationFinishedTime = 0.9f;

    public bool IsAbleToAttack;

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
        if (isAttacking && animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= animationFinishedTime)
        {
            isAttacking = false;
        }

        if(isAttacking == true)
        {
            RightHand.SetActive(true);
            LeftHand.SetActive(true);
        }
        else
        {
            RightHand.SetActive(false);
            LeftHand.SetActive(false);
        }
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
        if (IsAbleToAttack == true)
        {

            Attacking();
        }


    }

    public void AttackStop()
    {

    }


    public void Attacking()
    {
        if (!isAttacking)
        {
            animator.SetTrigger("IsAttacking");
            StartCoroutine(InitialiseAttack());

        }
    }

    IEnumerator InitialiseAttack()
    {
        yield return new WaitForSeconds(0.1f);
        isAttacking = true;
    }
}
