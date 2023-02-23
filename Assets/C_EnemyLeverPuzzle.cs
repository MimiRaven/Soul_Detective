using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EnemyLeverPuzzle : MonoBehaviour
{
    public GameObject LeverUp;
    public GameObject LeverDown;

    public GameObject Hazard;

    public GameObject PuzzleEnemy;

    public C_EnemyPossesed C_EnemyPossesed;
   // public Bot Bot;
    public C_PlayerController C_PlayerController;
    public C_PossesedEnemyAttack C_PossesedEnemyAttack;

  //  public Behaviour c_EnemyPossesed;
   // public Behaviour c_EnemyAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {


        if (col.collider.tag == "weapon")
        {
          
           // C_PossesedEnemyAttack.isAttacking = false;
            C_PlayerController.Possesed = true;
            C_EnemyPossesed.Possesed = false;
           // PuzzleEnemy.SetActive(false);
            Hazard.SetActive(false);
            LeverUp.SetActive(false);
            PuzzleEnemy.SetActive(false);
            LeverDown.SetActive(true);
            
            //c_EnemyPossesed.enabled= false;
            //c_EnemyAttack.enabled= false;
            //Bot.enabled= false;
        }
    }
}
