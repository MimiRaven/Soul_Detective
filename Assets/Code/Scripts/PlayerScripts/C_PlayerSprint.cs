using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_PlayerSprint : MonoBehaviour
{
    public C_PlayerController playerController;

    float stamina = 10, maxStamina = 10;
    float walkSpeed, runSpeed;
    bool isRunning;

    private InputAction sprintAction;

    [SerializeField]
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        sprintAction = playerInput.actions["Sprint"];

        //float playerSpeed = playerController.playerSpeed;
        walkSpeed = playerController.playerSpeed;
        runSpeed = walkSpeed + 5;
    }

    // Update is called once per frame
    void Update()
    {
        Sprinter.instance.SetValue(stamina / maxStamina);
    }

    private void OnEnable()
    {
        sprintAction.performed += _ => StartRun();
        sprintAction.canceled += _ => CancelRun();
    }

    private void OnDisable()
    {
        sprintAction.performed -= _ => StartRun();
        sprintAction.canceled -= _ => CancelRun();
    }


    public void StartRun()
    {
        Debug.Log("IsRunning");
        playerController.playerSpeed = 10;
    }

    public void CancelRun()
    {
        Debug.Log("NotRunning");
        playerController.playerSpeed = 5;
    }
}
