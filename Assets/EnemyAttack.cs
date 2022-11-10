using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Animator animator;

    public bool IsAttacking;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(IsAttacking == true)
        {

        animator.SetBool("Attack", true);
        }
        else
        {

             animator.SetBool("Attack", false);
        }
        //is attacking

        //is not attacking

    }
}
