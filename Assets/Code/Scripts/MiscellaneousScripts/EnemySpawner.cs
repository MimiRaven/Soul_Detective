using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;

    public float swarmerInterval = 1f;
    public float bigSwarmerInterval = 5f;

    private float timeBetweenWaves = 1f;
    public int waves = 2;
    public static float countdown;
    private int EnemyPerWave = 1;

    void Awake()
    {
        countdown = 1f;
    }

    void Start()
    {

    }

     void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && waves != 0)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
            waves -= 1;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < EnemyPerWave; i++)
        {
            StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
            StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);

    }
}