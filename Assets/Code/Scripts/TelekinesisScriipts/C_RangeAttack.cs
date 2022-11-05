using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class C_RangeAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    private InputAction GrabAction;
    private InputAction ThrowAction;

    public bool GrabRay;
    public bool ThrowRay;

    public bool ObjectGrabbed;

    public C_SwitchAimCam aimCam;

    public float range = 100;
    private C_Throwableobject ts;

    public float SetCoolDownTime;
    public float TimeLeft;
    public bool TimerOn;

    //[SerializeField]
    //private InputActionReference actionRefrance;

    [Tooltip("Hand that is the target destination of the pull")]
    public Transform hand;

    [Tooltip("Tag that is used to determine if an object is pullable or not")]
    public string pullableTag;

    [Tooltip("Force modifier, tweak it to suit your needs")]
    public float modifier = 1.0f;

    [Tooltip("The direction of the force that is pulling the object")]
    Vector3 pullForce;

    [Tooltip("Once an object is in the hand, save it to this variable")]
    public Transform heldObject;

    [Tooltip("The distance threshold in which the object is considered pulled to the hand")]
    public float positionDistanceThreshold;

    [Tooltip("The distance threshold in which the object's velocity is set to maximum")]
    public float velocityDistanceThreshold;

    [Tooltip("The maximum velocity of the object being pulled")]
    public float maxVelocity;

    [Tooltip("The velocity at which the object is thrown")]
    public float throwVelocity;

    public TextMeshProUGUI TimerUI;
    public GameObject TimerCanvas;


    void Awake()
    {
        GrabAction = playerInput.actions["GrabThrowObject"];
        ThrowAction = playerInput.actions["ThrowObject"];
    }

    private void OnEnable()
    {
        GrabAction.performed += _ => GrabStart();
        GrabAction.canceled += _ => GrabStop();

        ThrowAction.performed += _ => ThrowStart();
        ThrowAction.canceled += _ => ThrowStop();
    }

    private void OnDisable()
    {
        GrabAction.performed -= _ => GrabStart();
        GrabAction.canceled -= _ => GrabStop();

        ThrowAction.performed -= _ => ThrowStart();
        ThrowAction.canceled -= _ => ThrowStop();
    }

    void GrabStart()
    {
        if(ObjectGrabbed == false & TimerOn == false)
        {
             GrabRay = true;

        }
    }
    void GrabStop()
    {
        GrabRay = false;
       
    }

    void ThrowStart()
    {
        if (ObjectGrabbed)
        {
            ThrowRay = true;
            //ObjectGrabbed = false;
        }
    }
    void ThrowStop()
    {
        ThrowRay = false;
       
    }



    void Update()
    {
        Timmer();

        GrabObjectRayCast();
        WeaponActication();

        if (ObjectGrabbed == true)
        {
            GrabRay = false;
        }

       //Timmer();
       //TimerOn = true;
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
        TimerUI.text = string.Format("{0:0}", seconds);

    }

    void WeaponActication()
    {
        if (aimCam.AimOn == true)
        {
            if (GrabRay == true)
            {
                Vector3 direction = Vector3.forward;
                Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
                Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

                if (Physics.Raycast(theRay, out RaycastHit hit, range))
                {

                    if (hit.transform.TryGetComponent<C_Throwableobject>(out ts))
                        ts.WeaponActive = true;
                        


                }

            }

        }

    }


    void GrabObjectRayCast()
    {
        if (aimCam.AimOn == true)
        {
            if(TimerOn == false)
            {
                RaycastHit hit;
                if (GrabRay == true)
                {
                    if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
                    {
                        Debug.Log("RayAttackShot");
                        if (hit.transform.tag.Equals(pullableTag))
                        {
                            StartCoroutine(PullObject(hit.transform));
                            ObjectGrabbed = true;
                            ThrowRay = false;
                           
                        }
                    }
                }
                
                
                if (ThrowRay == true) //Pressing B (throwing object)
                {
                    if (heldObject != null && ObjectGrabbed)
                    {
                        heldObject.transform.parent = null;
                        heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        heldObject.GetComponent<Rigidbody>().velocity = transform.forward * throwVelocity;
                        heldObject = null;
                        ObjectGrabbed = false;
                        GrabRay = false;
                        TimerOn = true;
                        TimeLeft = SetCoolDownTime;
                    }
                }

            }


        }
    }

    IEnumerator PullObject(Transform t)
    {
        Rigidbody r = t.GetComponent<Rigidbody>();
        while (true)
        {

            //  If the player right-clicks, stop pulling
           //if (ThrowRay == true && ObjectGrabbed == true)
           //{
           //    break;
           //}

            float distanceToHand = Vector3.Distance(t.position, hand.position);
            /*
                If the object is withihn the distance threshold, consider it pulled all the way and:
                1) Set the object's position to the hand position
                2) make it's parent be the hand object
                3) Constrain its movement, but not rotation
                4) Set its velocity to be the forward vector of the camera * the throw velocity
                5) Break out of the coroutine
            */
            if (distanceToHand < positionDistanceThreshold)
            {
                t.position = hand.position;
                t.parent = hand;
                r.constraints = RigidbodyConstraints.FreezePosition;
                heldObject = t;
                break;
            }

            //  Calculate the pull direction vector
            Vector3 pullDirection = hand.position - t.position;

            //  Normalize it and multiply by the force modifier
            pullForce = pullDirection.normalized * modifier;

            /*
                Check if the velocity magnitude of the object is less than the maximum velocity
                and
                check if the distance to hand is greater than the distance threshold
            */
            if (r.velocity.magnitude < maxVelocity && distanceToHand > velocityDistanceThreshold)
            {

                //  Add force that takes the object's mass into account
                r.AddForce(pullForce, ForceMode.Force);
            }
            else
            {

                // Set a constant velocity to the object
                r.velocity = pullDirection.normalized * maxVelocity;
            }

            yield return null;
        }
    }
}
