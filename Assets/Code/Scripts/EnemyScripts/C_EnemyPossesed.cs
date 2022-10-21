using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    //Input System Variables
    private InputAction moveAction;
    private InputAction jumpAction;
    private PlayerInput playerInput;
    private InputAction StopPosAction;

    public bool Possesed;
   

    public C_PlayerController c_PlayerController;
    public C_EnemyRoam c_EnemyRoam;

    public GameObject EnemyCams;
    //private CinemachineVirtualCamera virtualCamera;

    public GameObject PlayerAndCams;



    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();

        cameraTransfrom = Camera.main.transform;
        //cameraTransfrom = GameObject.Find("Enemy 3rdPerson Cinima").GetComponent<Transform>();


        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        StopPosAction = playerInput.actions["StopPossesion"];

        Cursor.visible = false;

        Possesed = false;

        EnemyCams.SetActive(false);

        //virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {

        if (Possesed == true)
        {
            Debug.Log("Enemy Posesed");
            Movement();
            c_EnemyRoam.enabled = false;
            EnemyCams.SetActive(true);
            //PlayerAndCams.SetActive(false);
        }
        else 
        {
            Debug.Log("Enemy Not Possesd");
            
        }

       //if(c_PlayerController.Possesed == false)
       //{
       //    Possesed = true;
       //}
       //else { Possesed = false; }


        if (StopPosAction.triggered && Possesed)
        {
            Debug.Log("End Enemy Possesion"); 
            c_PlayerController.Possesed = true;
            Possesed = false;
            EnemyCams.SetActive(false);
            //PlayerAndCams.SetActive(true);

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
}
