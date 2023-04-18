using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public Bot BotScript;

    public Animator animator;
    public C_EmenyDeath c_EmenyDeath;

    public bool IsAttacking;

    public GameObject player;
    public GameObject Enemy;
    public float Distance_;

    public float AttackDistance;
    public float StopAttackingDistance;

    public C_PlayerController c_PlayerController;

    public PlayerTracker playerTracker;


    // public GameObject Weapon;

    // Start is called before the first frame update
    void Start()
    {
        //Weapon.SetActive(true);
       // agent = this.GetComponent<NavMeshAgent>();
       

      
    }

    

    // Update is called once per frame
    void Update()
    {

    
        Distance_ = Vector3.Distance(playerTracker.closestEnemy.transform.position, Enemy.transform.position);

        
        if(Distance_ < AttackDistance)
        {
            IsAttacking = true;
            //BotScript.speed = 0;
        }


        if (Distance_ > StopAttackingDistance)
        {
            IsAttacking = false;
            //BotScript.speed = 3;

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
