using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class C_Telekinesis : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;


    public float range = 100;

    public bool ObjectPush;
    public bool ObjectPull;
    public bool GrabObject;

    public bool ObjectGrabbed;


    public bool AimOn;

    private InputAction PullAction;
    private InputAction PushAction;
    private InputAction GrabAction;
    private InputAction DropAction;


    [SerializeField]
    private Transform objectGrabPointTransform;


    private Target ts;

    public bool ObjectDropped;

    public C_HoldPositionMover c_HoldPositionMover;
    public C_SwitchAimCam SwitchAimCam;


    public float SetCoolDownTime;
    public float TimeLeft;
    public bool TimerOn;

    public TextMeshProUGUI TimerUI;
    public GameObject TimerCanvas;

    public AudioSource audioSource;

    private void Awake()
    {
        PullAction = playerInput.actions["PullObject"];
        PushAction = playerInput.actions["PushObject"];
        GrabAction = playerInput.actions["GrabObject"];
        DropAction = playerInput.actions["DropObject"];
    }


    void Update()
    {

        Timmer();
        ObjectGrabRayCastShot();
        ObjectDropRayCastShot();

        if (SwitchAimCam.AimOn == false)
        {

            GrabStop();

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
                TimerCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("Time is Up");
                //TimeLeft = 0;
                TimerOn = false;
                TimerCanvas.SetActive(false);

            }

        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerUI.text = "Telekinesis Cooldown: " + string.Format("{0:0}", seconds);

    }


    void ObjectGrabRayCastShot()
    {
        if (SwitchAimCam.AimOn == true && GrabObject)
        {
            if (TimerOn == false)
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
                        GrabObject = false;

                        audioSource.Play();
                    }
                }

            }
        }
    }

    void ObjectDropRayCastShot()
    {
        if (SwitchAimCam.AimOn == true)
        {
            if (ObjectDropped == true & ObjectGrabbed)
            {
                Vector3 direction = Vector3.forward;
                Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
                Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));
                if (Physics.Raycast(theRay, out RaycastHit hit, range))
                {
                    if (hit.transform.TryGetComponent<Target>(out ts))
                    {
                        ts.Dropped = true;
                        ObjectGrabbed = false;
                        TimerOn = true;
                        TimeLeft = SetCoolDownTime;
                        Debug.Log("RayCast Hit Obj");
                        audioSource.Stop();
                    }
                }
            }
        }
    }

    private void OnEnable()
    {



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

    //Telekinisis
    private void PullStart()
    {
        ObjectPull = true;

        if (c_HoldPositionMover.PushandpullRange > -15)
        {
            c_HoldPositionMover.ObjectPulled = true;

        }

        //c_HoldPositionMover.Pull();


    }
    private void PullStop()
    {
        ObjectPull = false;
        c_HoldPositionMover.ObjectPulled = false;

    }

    private void PushStart()
    {
        if (c_HoldPositionMover.PushandpullRange < 250)
        {
            c_HoldPositionMover.ObjectPushed = true;
        }
        ObjectPush = true;



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
        //ObjectGrabbed = false;


    }


    private void GrabStart()
    {

        //if (ObjectGrabbed == false)
        // {
        GrabObject = true;

        //}





    }
    private void GrabStop()
    {
        GrabObject = false;


    }










}
