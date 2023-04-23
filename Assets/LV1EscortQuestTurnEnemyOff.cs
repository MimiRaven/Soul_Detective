using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1EscortQuestTurnEnemyOff : MonoBehaviour
{
    public Diolouge diologe;
    public GameObject Self;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (diologe.TextEnded == true)
        {
            Self.SetActive(false);
        }
    }
}
