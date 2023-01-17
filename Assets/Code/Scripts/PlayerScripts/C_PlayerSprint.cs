using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_PlayerSprint : MonoBehaviour
{
    public C_PlayerController c_PlayerController;
    private InputAction sprintAction;
    private InputAction dodgeAction;

    [SerializeField]
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    void Awake()
    {
        sprintAction = playerInput.actions["Sprint"];
        dodgeAction = playerInput.actions["Dodge"];


    }

    // Update is called once per frame
    void Update()
    {
        //Sprinter.instance.SetValue(stamina / maxStamina);
    }

    private void OnEnable()
    {
        sprintAction.performed += _ => StartRun();
        sprintAction.canceled += _ => CancelRun();

        dodgeAction.performed += _ => StartDodge();
        dodgeAction.canceled += _ => StopDodge();
    }

    private void OnDisable()
    {
        sprintAction.performed -= _ => StartRun();
        sprintAction.canceled -= _ => CancelRun();

        dodgeAction.performed -= _ => StartDodge();
        dodgeAction.canceled -= _ => StopDodge();
    }


    public void StartRun()
    {
        Debug.Log("IsRunning");
        c_PlayerController.isRunning = true;
    }

    public void CancelRun()
    {
        Debug.Log("NotRunning");
       c_PlayerController.isRunning = false;
    }

    public void StartDodge()
    {
       // GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        
    }

    public void StopDodge()
    {

    }
}
