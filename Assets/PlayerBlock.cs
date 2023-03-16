using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;


    private InputAction Block;

    public bool IsBlocking;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        Block = playerInput.actions["Block"];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        Block.performed += _ => BlockStart();
        Block.canceled += _ => BlockSop();


    }

    private void OnDisable()
    {
        Block.performed -= _ => BlockStart();
        Block.canceled -= _ => BlockSop();


    }

    void BlockStart()
    {
        IsBlocking = true;
    }

    void BlockSop()
    {
        IsBlocking= false;
    }
}
