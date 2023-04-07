using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class C_Possesion : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField] private LayerMask layerMask;

    public bool PossesionRayShot;
    public float range = 100;

    public bool AimOn;

    private InputAction ShootAction;

    public C_PlayerController c_PlayerController;
    public C_SwitchAimCam SwitchAimCam;

    public float SetCoolDownTime;
    public float TimeLeft;
    public bool TimerOn;
    public C_PossesionTimmer c_PossesionTimmer;
    //public C_PlayerController c_PlayerController;

    //public Text TimerUI;
    public TextMeshProUGUI TimerUI;
    public GameObject TimerCanvas;


    private void Awake()
    {
        ShootAction = playerInput.actions["Shoot"];


    }



    void Update()
    {
        TimerUI.text = TimeLeft.ToString();

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
                TimerCanvas.SetActive(true);
               

            }
            else
            {
                Debug.Log("Time is Up");
                TimerOn = false;
                TimerCanvas.SetActive(false);
                

            }

        }
        else
        {
            TimeLeft = SetCoolDownTime;
        }
   
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerUI.text = "Possesion CoolDown: " + string.Format("{0:0}", seconds);

    }

    public void ExitPossesion()
    {
        if (TimeLeft >= 0)
        {
            c_PlayerController.Possesed = true;
        }
    }



    void PossesionRayCastShot()
    {
        if (SwitchAimCam.AimOn == true)
        {

            if(TimerOn == false)
            {

                 if (PossesionRayShot == true)
                 {
                     Vector3 direction = Vector3.forward;
                     Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
                     Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

                     Debug.Log("Possesion Ray Shot");



                     if (Physics.Raycast(theRay, out RaycastHit hit, range))
                     {
                       

                             Debug.Log("Push button active");
                             if (hit.transform.TryGetComponent<C_EnemyPossesed>(out C_EnemyPossesed ts))
                                 ts.Possesed = true;

                             if(ts.Possesed == true && ts.PuzzleEnemy == false)
                              {

                                    
                           
                             c_PossesionTimmer.TimerOn = true;
                             c_PlayerController.Possesed = false;
                             PossesionRayShot = false;
                             TimerOn = true;
                             

                             }
                             else if(ts.Possesed == true && ts.PuzzleEnemy == true)
                        {
                            c_PlayerController.Possesed = false;
                            PossesionRayShot = false;
                            TimerOn = true;
                        }

                       //if (hit.transform.TryGetComponent<C_PuzzleEnemyPossesion>(out C_PuzzleEnemyPossesion Ps))
                       //    Ps.Possesed = true;
                       //Debug.Log("PuzzleScriptHit");
                       //if (Ps.Possesed == true)
                       //{
                       //    
                       //    c_PlayerController.Possesed = false;
                       //    PossesionRayShot = false;
                       //    c_PossesionTimmer.TimerCanvas.SetActive(false);
                       //}











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
        PossesionRayShot = true;
    }
    private void StopShoot()
    {
        PossesionRayShot = false;

    }
}
