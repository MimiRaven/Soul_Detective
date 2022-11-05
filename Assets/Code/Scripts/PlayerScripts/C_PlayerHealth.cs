using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_PlayerHealth : MonoBehaviour
{
    public C_PlayerController player;

    public int maxHealth = 10;
    public int health { get { return currentHealth; } }
    int currentHealth;

    private bool isRespawning;
    private Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        respawnPoint = player.transform.position;
    }


    public void ChangeHealth(int amount)
    {
        if (currentHealth <= 1)
        {
            Respwan();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    public void Respwan()
    {
        Debug.Log("PlayerRespawned");
        player.transform.position = respawnPoint;
        currentHealth = maxHealth;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
