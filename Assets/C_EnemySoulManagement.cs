using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EnemySoulManagement : MonoBehaviour
{
    public C_EnemyPossesed enemyPossesed;
    public Behaviour c_PossesedEnemyAttack;

    public Behaviour camDetectText;
    public Behaviour enemyAttack;

    public Behaviour Bot;
    public Behaviour NavMeshAgent;

    public CharacterController characterController;

    
    // Start is called before the first frame update
    void Start()
    {
        characterController= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyPossesed.Possesed == true)
        {
            Bot.enabled = false;
            camDetectText.enabled = false;
            enemyAttack.enabled = false;
            NavMeshAgent.enabled = false;
            characterController.enabled = true;

            c_PossesedEnemyAttack.enabled = true;

        }
        else
        {
            Bot.enabled = true; 
            camDetectText.enabled = true;
                
            enemyAttack.enabled = true;
            NavMeshAgent.enabled = true;

            c_PossesedEnemyAttack.enabled = false;
            characterController.enabled = false;
        }


    }
}
