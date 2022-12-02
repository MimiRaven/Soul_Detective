using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Animator animator;
    public C_EmenyDeath c_EmenyDeath;

    public bool IsAttacking;

    public GameObject player;
    public GameObject Enemy;
    public float Distance_;

   // public GameObject Weapon;

    // Start is called before the first frame update
    void Start()
    {
        //Weapon.SetActive(true);
    }

    

    // Update is called once per frame
    void Update()
    {

        Distance_ = Vector3.Distance(player.transform.position, Enemy.transform.position);

        if(Distance_ < 5)
        {
            IsAttacking = true;
        }
        else if (Distance_ > 5)
        {
            IsAttacking = false;
        }

        if (IsAttacking == true && c_EmenyDeath.EnemyCurrentHealth > 0)
        {

             animator.SetBool("IsAttacking", true);
            //Weapon.SetActive(true);
        }
        else
        {
           // Weapon.SetActive(false);
            animator.SetBool("IsAttacking", false);
        }
        //is attacking

        //is not attacking

    }
}
