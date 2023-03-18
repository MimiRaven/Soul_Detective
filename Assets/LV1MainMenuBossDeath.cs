using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LV1MainMenuBossDeath : MonoBehaviour
{
    public C_EmenyDeath emenyDeath;
    public LevelCompletionManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(emenyDeath.EnemyCurrentHealth == 0)
        {
            SceneManager.LoadScene("HubWorld");
            levelManager.Lv1Complete = true;
        }
    }
}
