using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_NavArrowActivation : MonoBehaviour
{

    [SerializeField]
    private PlayerInput playerInput;
    private InputAction NavArrowAction;

    public GameObject NavArrow;
    public bool ArrowActivated;

    // Start is called before the first frame update
    void Awake()
    {
        NavArrowAction = playerInput.actions["NavigationArrow"];
        
    }

    void Update()
    {
        if (ArrowActivated == false)
        {
            NavArrow.SetActive(false);
        }
        else
        {
            NavArrow.SetActive(true);
        }
    }

    private void OnEnable()
    {
        NavArrowAction.performed += _ => ArrowOn();
        NavArrowAction.canceled += _ => ArrowOff();

    }

    private void OnDisable()
    {
        NavArrowAction.performed -= _ => ArrowOn();
        NavArrowAction.canceled -= _ => ArrowOff();

    }

    void ArrowOn()
    {
        ArrowActivated = true;
    }
    void ArrowOff()
    {
        ArrowActivated = false;

    }


}
