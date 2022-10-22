using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class C_SwitchAimCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int priorityBoostAmount = 10;

    public GameObject aimCanvas;

    public bool RayCastShot;
    public float range = 100;

    public bool ObjectPush;
    public bool ObjectPull;
    public bool GrabObject;

    public bool ObjectGrabbed;

    public bool AimOn;


    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;
    private InputAction ShootAction;
    private InputAction PullAction;
    private InputAction PushAction;
    private InputAction GrabAction;

    private InputAction DropAction;

    public C_EnemyPossesed c_EnemyPossesed;

    public C_EnemyPossesed c_Enemy2;
    //public GameObject EnemyCams;

    public C_PlayerController c_PlayerController;

    //[SerializeField]
    //private Transform playerCameraTransform;
    //[SerializeField]
    //private LayerMask pickUpLayerMask;
    //float pickUpDistance = 2f;

    [SerializeField]
    private Transform objectGrabPointTransform;


    private Target ts;

    public bool ObjectDropped;

    public C_HoldPositionMover c_HoldPositionMover;



    //public C_NonRoamingEnemys c_NonRoamingEnemys;
    //public Game Object NonRoamingEnemyCams;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
        ShootAction = playerInput.actions["Shoot"];

        PullAction = playerInput.actions["PullObject"];
        PushAction = playerInput.actions["PushObject"];
        GrabAction = playerInput.actions["GrabObject"];
        DropAction = playerInput.actions["DropObject"];
    }



    void Update()
    {
        PossesionRayCastShot();


        ObjectGrabRayCastShot();
        ObjectDropRayCastShot();

        //if (ObjectGrabbed == true)
        //{
        //    GrabObject = false;
        //}
        //
        if (AimOn == false)
        {
            StopShoot();
            //PullStop();
            //PushStop();
            GrabStop();

        }
    }

    void ObjectGrabRayCastShot()
    {
        if (AimOn == true)
        {
            if (GrabObject == true)
            {
                Vector3 direction = Vector3.forward;
                Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
                Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

                if (Physics.Raycast(theRay, out RaycastHit hit, range))
                {

                    if (hit.transform.TryGetComponent<Target>(out ts))
                    {
                        ts.Grab(objectGrabPointTransform);

                        ObjectGrabbed = true;
                    }



                }
            }
        }
    }

    void ObjectDropRayCastShot()
    {

        if (AimOn == true)
        {
            if (ObjectDropped == true & ObjectGrabbed)
            {
                Vector3 direction = Vector3.forward;
                Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
                Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));



                if (Physics.Raycast(theRay, out RaycastHit hit, range))
                {

                    if (hit.transform.TryGetComponent<Target>(out ts))
                        ts.Dropped = true;
                    Debug.Log("RayCast Hit Obj");

                    ObjectGrabbed = false;

                    //ts.Dropped = true;


                }




            }


        }

    }

    void PossesionRayCastShot()
    {
        if (AimOn == true)
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
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();

        ShootAction.performed += _ => StartShoot();
        ShootAction.canceled += _ => StopShoot();


        //telikinisis
        PullAction.performed += _ => PullStart();
        PullAction.canceled += _ => PullStop();

        PushAction.performed += _ => PushStart();
        PushAction.canceled += _ => PushStop();

        GrabAction.performed += _ => GrabStart();
        GrabAction.canceled += _ => GrabStop();

        DropAction.performed += _ => DropStart();
        DropAction.canceled += _ => DropStop();

    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();

        ShootAction.performed -= _ => StartShoot();
        ShootAction.canceled -= _ => StopShoot();

        //telikinisis
        PullAction.performed -= _ => PullStart();
        PullAction.canceled -= _ => PullStop();

        PushAction.performed -= _ => PushStart();
        PushAction.canceled -= _ => PushStop();

        GrabAction.performed -= _ => GrabStart();
        GrabAction.canceled -= _ => GrabStop();

        DropAction.performed -= _ => DropStart();
        DropAction.canceled -= _ => DropStop();
    }




    private void StartAim()
    {
        AimOn = true;
        virtualCamera.Priority += priorityBoostAmount;
        aimCanvas.SetActive(true);
    }
    private void CancelAim()
    {
        AimOn = false;
        virtualCamera.Priority -= priorityBoostAmount;
        aimCanvas.SetActive(false);

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



    //Telekinisis
    private void PullStart()
    {
        ObjectPull = true;
        c_HoldPositionMover.ObjectPulled = true;
        //c_HoldPositionMover.Pull();


    }
    private void PullStop()
    {
        ObjectPull = false;
        c_HoldPositionMover.ObjectPulled = false;

    }

    private void PushStart()
    {
        ObjectPush = true;
        c_HoldPositionMover.ObjectPushed = true;
        //c_HoldPositionMover.Push();
    }
    private void PushStop()
    {
        ObjectPush = false;
        c_HoldPositionMover.ObjectPushed = false;

    }

    void DropStart()
    {
        if (ObjectGrabbed)
        {
            ObjectDropped = true;

        }

    }

    void DropStop()
    {
        ObjectDropped = false;
    }


    private void GrabStart()
    {

        GrabObject = true;



    }
    private void GrabStop()
    {
        GrabObject = false;


    }




}
