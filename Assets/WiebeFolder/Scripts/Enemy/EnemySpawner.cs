using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [Header("Spawn Settings")]
    [SerializeField] private List<Transform> enemySpawnPoints;
    [SerializeField] private List<GameObject> enemyTypes;

    [SerializeField] private int poolSizePerEnemy = 10;

    [Header("Timers")]
    [SerializeField] private float spawnDelay = 1f;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI roundText;

    private List<GameObject> pooledEnemies = new();

    private int currentRound = 1;
    private int enemiesToSpawn = 10;
    private int enemiesSpawned = 0;

    public int enemiesAlive = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CreatePool();
        StartCoroutine(SpawnRound());
    }

    void Update()
    {
        roundText.text = $"Round {currentRound}";
    }

    private void CreatePool()
    {
        foreach (GameObject prefab in enemyTypes)
        {
            for (int i = 0; i < poolSizePerEnemy; i++)
            {
                GameObject enemy = Instantiate(prefab);
                enemy.SetActive(false);

                pooledEnemies.Add(enemy);
            }
        }
    }

    private GameObject GetRandomPooledEnemy()
    {
        List<GameObject> availableEnemies = new();

        foreach (GameObject enemy in pooledEnemies)
        {
            if (!enemy.activeInHierarchy)
            {
                availableEnemies.Add(enemy);
            }
        }

        if (availableEnemies.Count == 0)
            return null;

        return availableEnemies[Random.Range(0, availableEnemies.Count)];
    }

    private void SpawnEnemy()
    {
        GameObject enemy = GetRandomPooledEnemy();

        if (enemy == null)
            return;

        Transform spawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)];

        enemy.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);

        enemy.SetActive(true);

        enemiesAlive++;
        enemiesSpawned++;
    }

    IEnumerator SpawnRound()
    {
        enemiesSpawned = 0;

        int initialEnemies = Mathf.Min(enemySpawnPoints.Count, enemiesToSpawn);

        for (int i = 0; i < initialEnemies; i++)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(spawnDelay);
        }

        yield return new WaitUntil(() => enemiesAlive == 0 && enemiesSpawned >= enemiesToSpawn);
        yield return new WaitForSeconds(spawnDelay);

        RoundUp();
        StartCoroutine(SpawnRound());
    }

    public void EnemyDied(GameObject enemy)
    {
        enemiesAlive--;

        enemy.SetActive(false);

        if (enemiesSpawned < enemiesToSpawn)
        {
            SpawnEnemy();
        }
    }

    void RoundUp()
    {
        currentRound++;
        enemiesToSpawn += 10;
        enemiesSpawned = 0;
        enemiesAlive = 0;
    }
}