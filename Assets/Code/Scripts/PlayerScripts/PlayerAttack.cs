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

    public bool isAttacking;

    AudioSource audioSource;
    public AudioClip[] audioClipArray;

    [SerializeField]
    private float animationFinishedTime = 0.9f;

    public bool IsAbleToAttack;

    public GameObject AttackColider;

    public bool FaceEnemy;

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


        //if (isAttacking == true)
        //{
        //    AttackColider.SetActive(true);
        //    
        //}
        //else
        //{
        //    AttackColider.SetActive(false);
        //   
        //}


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
            FaceEnemy = true;
        }


    }

    public void AttackStop()
    {
        //isAttacking = false;
    }


    public void ColliderON()
    {
        AttackColider.SetActive(true);
    }

    public void ColliderOff()
    {
        AttackColider.SetActive(false);
        FaceEnemy = false;
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