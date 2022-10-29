using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_Possesion : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    public bool RayCastShot;
    public float range = 100;

    public bool AimOn;

    private InputAction ShootAction;

    public C_EnemyPossesed c_EnemyPossesed;

    public C_EnemyPossesed c_Enemy2;

    public C_PlayerController c_PlayerController;
    public C_SwitchAimCam SwitchAimCam;

    private void Awake()
    {
        ShootAction = playerInput.actions["Shoot"];


    }



    void Update()
    {
        PossesionRayCastShot();

        if (SwitchAimCam.AimOn == false)
        {
            StopShoot();

        }
    }



    void PossesionRayCastShot()
    {
        if (SwitchAimCam.AimOn == true)
        {


            if (RayCastShot == true)
            {
                Vector3 direction = Vector3.forward;
                Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
                Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

                Debug.Log("Possesion Ray Shot");



                if (Physics.Raycast(theRay, out RaycastHit hit, range))
                {
                    //if (ObjectPush == true)
                    //{
                    //    Debug.Log("Push button active");
                    //    if (hit.transform.TryGetComponent<Target>(out Target ts))
                    //        ts.GetShot(theRay.direction);
                    //}
                    //else { Debug.Log("Push button Not active"); }



                    //Enemy Possesion
                    if (hit.collider.tag == "Enemy1")
                    {

                        Debug.Log("Enemy1 Hit confirmed");
                        //tpMovement.Possesed = true;
                        c_EnemyPossesed.Possesed = true;
                        c_PlayerController.Possesed = false;

                        //EnemyCams.SetActive(true);
                        //PlayerCams.SetActive(false);
                        RayCastShot = false;
                        //virtualCamera.Priority -= priorityBoostAmount;
                        //c_NonRoamingEnemys.Possesed

                    }
                    else
                    {
                        Debug.Log("Enemy1 Not Hit");
                        //EnemyCams.SetActive(false);
                        //PlayerCams.SetActive(true);

                    }
                    if (hit.collider.tag == "Enemy2")
                    {

                        Debug.Log("Enemy2 Hit confirmed");
                        //tpMovement.Possesed = true;
                        c_PlayerController.Possesed = false;
                        c_Enemy2.Possesed = true;
                        //EnemyCams.SetActive(true);
                        //PlayerCams.SetActive(false);
                        RayCastShot = false;
                        //virtualCamera.Priority -= priorityBoostAmount;

                        //c_NonRoamingEnemys.Possesed


                    }
                    else
                    {
                        Debug.Log("Enemy2 Not Hit");
                        //EnemyCams.SetActive(false);
                        //PlayerCams.SetActive(true);

                    }

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
        RayCastShot = true;
    }
    private void StopShoot()
    {
        RayCastShot = false;

    }
}
