using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.Shapes;

public class C_PlayerSprint : MonoBehaviour
{
    public C_PlayerController c_PlayerController;
    private InputAction sprintAction;
    private InputAction dodgeAction;

    [SerializeField]
    private PlayerInput playerInput;

    public float pushForce = 0;

    public Rigidbody rb;
    //public float Magnitude;

    //Vector3 ImpulseVector = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
      // rb = GetComponent<Rigidbody>();
        //m_Rigidbody = GetComponent<Rigidbody>();

    }

    void Awake()
    {
        sprintAction = playerInput.actions["Sprint"];
        dodgeAction = playerInput.actions["Dodge"];


    }

    // Update is called once per frame
    void Update()
    {
        

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
       // Doudge();

       // c_PlayerController.isDodging = true;
        Debug.Log("Doudge pressed");
        DoudgeFunction();

        //rb.AddForce(transform.forward * 100);

        //rb.AddForce(0, 0, pushForce, ForceMode.Impulse);
    }

    public void StopDodge()
    {
        //c_PlayerController.isDodging = false;
    }

   public void DoudgeFunction()
   {
       if(c_PlayerController.CurrentStamina >=0)
       {
         c_PlayerController.playerSpeed = 500;
         c_PlayerController.CurrentStamina -= 1;
   
       }
   }

   //public void Doudge(Vector3 direction)
   //{
   //    
   //    Vector3 force = direction * pushForce + Vector3.zero * 500;
   //    this.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
   //    this.transform.parent = null;
   //}

    private void FixedUpdate()
    {
        //rb.AddForce(transform.forward * 100);

    }

}
