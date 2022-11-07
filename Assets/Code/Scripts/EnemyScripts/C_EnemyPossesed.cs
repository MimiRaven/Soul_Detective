using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]

public class C_EnemyPossesed : MonoBehaviour
{
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
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction StopPosAction;

    public bool Possesed;


    public C_PlayerController c_PlayerController;
    //public C_EnemyRoam c_EnemyRoam;

    public GameObject EnemyCams;


    public GameObject PlayerAndCams;

    public float SetCoolDownTime;
    public float TimeLeft;
    public bool TimerOn;

    public TextMeshProUGUI TimerUI;
    public GameObject TimerCanvas;

    private Rigidbody objectRb;
    
    //public NavMeshAgent agent;

    private void Awake()
    {
        StopPosAction = playerInput.actions["StopPossesion"];
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        objectRb = GetComponent<Rigidbody>();
        //agent = GetComponent<NavMeshAgent>();
    }


    private void Start()
    {

        TimeLeft = SetCoolDownTime;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];

        cameraTransfrom = Camera.main.transform;
        EnemyCams.SetActive(false);
        
        //Cursor.visible = false;

        //Possesed = false;

        Possesed = false;
        EnemyCams.SetActive(false);
        


    }

    void Update()
    {
        
        Possesion();
        
    }

    void Timmer()
    {

        if (TimerOn)
        {

            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
                TimerCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("Time is Up");
                TimeLeft = 0;
                TimerOn = false;
                Possesed = false;
                TimerCanvas.SetActive(false);

            }

        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerUI.text = string.Format("{0:0}", seconds);
    }

   

    void Possesion()
    {
        //TimeLeft = SetCoolDownTime;


        if (Possesed == true)
        {
            Timmer();
            
            Debug.Log("Enemy Posesed");
            Movement();
            //c_EnemyRoam.enabled = false;
            EnemyCams.SetActive(true);
            
            TimerOn = true;
            objectRb.drag = 1;
        }
        else
        {
            TimeLeft = SetCoolDownTime;
            Debug.Log("End Enemy Possesion");
            c_PlayerController.Possesed = true;
            TimerOn = false;
            EnemyCams.SetActive(false);
            objectRb.drag = 100;
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
        Possesed = false;
        TimerCanvas.SetActive(false);
    }
    private void StopExitPossesion()
    {
        Possesed = false;

    }
}
