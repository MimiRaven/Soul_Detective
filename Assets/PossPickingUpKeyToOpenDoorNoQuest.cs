using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossPickingUpKeyToOpenDoorNoQuest : MonoBehaviour
{
    public GameObject Door;

    public GameObject PuzzleEnemy;

    public C_EnemyPossesed C_EnemyPossesed;
    // public Bot Bot;
    public C_PlayerController C_PlayerController;
    public C_PossesedEnemyAttack C_PossesedEnemyAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            C_PlayerController.Possesed = true;
            C_EnemyPossesed.Possesed = false;
            PuzzleEnemy.SetActive(false);

            Door.SetActive(false);
          

          

            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            C_PlayerController.Possesed = true;
            C_EnemyPossesed.Possesed = false;
            PuzzleEnemy.SetActive(false);

            Door.SetActive(false);
        

          

            Destroy(gameObject);

        }
    }
}
