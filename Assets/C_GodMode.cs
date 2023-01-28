using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_GodMode : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;


    private InputAction GodMode;

    public C_PlayerController PlayerController;
    public C_PlayerHealth PlayerHealth;
    public GameObject GodModeCanvas;

    public bool GodModeActive;

    void Awake()
    {
        GodMode = playerInput.actions["GodMode"];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GodModeActive == true)
        {
            //PlayerHealth.currentHealth = PlayerHealth.maxHealth;
            PlayerHealth.TimeLeft = 1;
            PlayerHealth.TimerOn = true;
            PlayerController.CurrentStamina =PlayerController.MaxStamina;
            PlayerHealth.TimerCanvas.SetActive(false);
            GodModeCanvas.SetActive(true);
        }
        else
        {
            // PlayerHealth.currentHealth = PlayerHealth.maxHealth;
            //PlayerController.CurrentStamina = PlayerController.MaxStamina;
            // PlayerHealth.TimerOn = false;
            //PlayerHealth.TimeLeft = 0;
            GodModeCanvas.SetActive(false);
        }
    }

    private void OnEnable()
    {
        GodMode.performed += _ => GodModeStart();
        GodMode.canceled += _ => GodModeStop();


    }

    private void OnDisable()
    {
        GodMode.performed -= _ => GodModeStart();
        GodMode.canceled -= _ => GodModeStop();


    }

    void GodModeStart()
    {
        GodModeActive = !GodModeActive;
    }
    void GodModeStop()
    {

    }
}
