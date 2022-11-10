using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Animator animator;

    public bool IsAttacking;

    public GameObject player;
    public GameObject Enemy;
    public float Distance_;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    

    // Update is called once per frame
    void Update()
    {

        Distance_ = Vector3.Distance(player.transform.position, Enemy.transform.position);

        if(Distance_ < 3)
        {
            IsAttacking = true;
        }
        else if (Distance_ > 3)
        {
            IsAttacking = false;
        }
        
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
