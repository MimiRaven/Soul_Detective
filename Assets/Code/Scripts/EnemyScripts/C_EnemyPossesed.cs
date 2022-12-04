using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(CharacterController))]

public class C_EnemyPossesed : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private PlayerInput playerInput;

    //Player Values
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    public float rotationSpeed = .8f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Transform cameraTransfrom;

    private InputAction moveAction;
    private InputAction jumpAction;
    //[SerializeField]
   
    private InputAction StopPosAction;

    public bool Possesed;

    public GameObject WeaponWheel;


    public C_PlayerController c_PlayerController;
    //public C_EnemyRoam c_EnemyRoam;

    public GameObject EnemyCams;


    public GameObject PlayerAndCams;

   //public float SetCoolDownTime;
   //public float TimeLeft;
   //public bool TimerOn;

    public TextMeshProUGUI TimerUI;
    public GameObject TimerCanvas;

    private Rigidbody objectRb;

    //public GameObject Door;

    public GameObject PlayerInputObject;

    //public ParticleSystem leaveBody;

   // public AudioClip Key;
    //public AudioSource audioSource;

   

    private void Awake()
    {
        StopPosAction = playerInput.actions["StopPossesion"];
        controller = GetComponent<CharacterController>();
        //playerInput = GetComponent<PlayerInput>();
        objectRb = GetComponent<Rigidbody>();
        //agent = GetComponent<NavMeshAgent>();
    }


    private void Start()
    {

        //TimeLeft = SetCoolDownTime;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        //StopPosAction = playerInput.actions["StopPossesion"];

        cameraTransfrom = Camera.main.transform;
        EnemyCams.SetActive(false);
        
        //Cursor.visible = false;

        //Possesed = false;

        Possesed = false;
        EnemyCams.SetActive(false);

        //leaveBody.Stop();                                             //

        //audioSource.Stop();                                         //

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {

            Possesed = false;
           // audioSource.Play();                                       //

            //Destroy(gameObject);

            //Debug.Log("Key Touched");
            //c_EnemyPossesed.Possesed = false;
            ////Self.SetActive(false);
            //Door.SetActive(false);
            ////OtherEnemy.SetActive(true);
            //
            //Destroy(other.gameObject);
            //Destroy(gameObject);
        }
    }

    void Update()
    {
        
        Possesion();
        
    }

  
   

    void Possesion()
    {
        //TimeLeft = SetCoolDownTime;


        if (Possesed == true)
        {
            //Timmer();
            c_PlayerController.Possesed = false;
            Debug.Log("Enemy Posesed");
            Movement();
            //leaveBody.Play();                                         //
            //c_EnemyRoam.enabled = false;
            EnemyCams.SetActive(true);
            
            //TimerOn = true;
            objectRb.drag = 1;
            WeaponWheel.SetActive(false);
            PlayerInputObject.SetActive(true);
            //leaveBody.Stop();

        }
        else
        {
            //TimeLeft = SetCoolDownTime;
            Debug.Log("End Enemy Possesion");
            //c_PlayerController.Possesed = true;
           // TimerOn = false;
            EnemyCams.SetActive(false);
            objectRb.drag = 100;
            WeaponWheel.SetActive(true);
            PlayerInputObject.SetActive(false);
            //leaveBody.Play();
            //leaveBody.Stop();
            //agent.enable = false;
        }

    }

    void Movement()
    {
        //Player Movement Code
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransfrom.right.normalized + move.z * cameraTransfrom.forward.normalized;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move.x > 0 || move.x < 0 || move.z > 0 || move.z < 0)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("Idleing", false);
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("Idleing", true);
        }


        //Player Rotation  
        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //Player Jump Code
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        
    }

    private void OnEnable()
    {
        StopPosAction.performed += _ => StartExitPossesion();
        StopPosAction.canceled += _ => StopExitPossesion();
    }

    private void OnDisable()
    {
        StopPosAction.performed -= _ => StartExitPossesion();
        StopPosAction.canceled -= _ => StopExitPossesion();
    }

    
    private void StartExitPossesion()
    {

        Debug.Log("QuitPressed");
        Possesed = false;
        c_PlayerController.Possesed = true;
        //leaveBody.Play();                                     //
        //leaveBody.Stop();

        //TimerCanvas.SetActive(false);
    }
    private void StopExitPossesion()
    {
        Possesed = false;
        //leaveBody.Play();
        //leaveBody.Stop();                                     //
    }
}
