using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_Possesion : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    public bool PossesionRayShot;
    public float range = 100;

    public bool AimOn;

    private InputAction ShootAction;

    public C_PlayerController c_PlayerController;
    public C_SwitchAimCam SwitchAimCam;

    public float SetCoolDownTime;
    public float TimeLeft;
    public bool TimerOn;

    private void Awake()
    {
        ShootAction = playerInput.actions["Shoot"];


    }



    void Update()
    {
        Timmer();
        PossesionRayCastShot();

        if (SwitchAimCam.AimOn == false)
        {
            StopShoot();

        }
    }

    void Timmer()
    {

        if (TimerOn)
        {

            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is Up");
                TimerOn = false;

            }

        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);


    }

    void PossesionRayCastShot()
    {
        if (SwitchAimCam.AimOn == true)
        {


            if (PossesionRayShot == true)
            {
                Vector3 direction = Vector3.forward;
                Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
                Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

                Debug.Log("Possesion Ray Shot");



                if (Physics.Raycast(theRay, out RaycastHit hit, range))
                {
                    if (PossesionRayShot == true)
                    {
                        Debug.Log("Push button active");
                        if (hit.transform.TryGetComponent<C_EnemyPossesed>(out C_EnemyPossesed ts))
                            ts.Possesed = true;
                        c_PlayerController.Possesed = false;
                        PossesionRayShot = false;
                    }
                    else { Debug.Log("Push button Not active"); }



                   

                }

            }
        }

    }

    private void OnEnable()
    {
        ShootAction.performed += _ => StartShoot();
        ShootAction.canceled += _ => StopShoot();
    }

    private void OnDisable()
    {
        ShootAction.performed -= _ => StartShoot();
        ShootAction.canceled -= _ => StopShoot();
    }

    //RayCast
    private void StartShoot()
    {
        PossesionRayShot = true;
    }
    private void StopShoot()
    {
        PossesionRayShot = false;

    }
}
