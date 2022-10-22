using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void OnAttack()
    {
        animator.SetTrigger("attack");
    }
}