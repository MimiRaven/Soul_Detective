using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;

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

    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;

    public bool firstAttackDone;
    public bool secondAttackDone;
    public bool thirdAttackDone;

    public bool AttackActive;



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
       


        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

       

        if (noOfClicks == 0)
        {
            firstAttackDone = false;
            secondAttackDone = false;
            anim.SetBool("hit1", false);
            anim.SetBool("hit2", false);
            anim.SetBool("hit3", false);

            AttackActive = false;



        }

        if(noOfClicks > 0)
        {
            AttackActive = true;
        }

        if (noOfClicks >= 1 && !firstAttackDone)
        {
            anim.SetBool("hit1", true);
           
        }

       
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "EnemyWeapon")
        {
            noOfClicks = 0;
        }
    }

    void OnClick()
    {
        
        lastClickedTime = Time.time;
        noOfClicks++;

        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

    }

    void FirstAttack()
    {
        if (noOfClicks == 1)
        {
            noOfClicks = 0;
        }

        firstAttackDone = true;
        secondAttackDone = false;
        
        anim.SetBool("hit1", false);

        if (noOfClicks >= 2 && firstAttackDone)
        {
      
            anim.SetBool("hit2", true);
        }
    }

    void SecondAttack()
    {
        if (noOfClicks == 2)
        {
            noOfClicks = 0;
        }

        firstAttackDone = false;
        secondAttackDone = true;
       
        anim.SetBool("hit2", false);

        if (noOfClicks >= 3 && secondAttackDone)
        {
           
            anim.SetBool("hit3", true);
        }
    }

    void thirdAttack()
    {
        //noOfClicks = 0;
        secondAttackDone = false;
        anim.SetBool("hit3", false);
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
            if (Time.time > nextFireTime)
            {
                OnClick();


            }
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
            // animator.SetTrigger("IsAttacking");
            //StartCoroutine(InitialiseAttack());

        }
    }

    

}