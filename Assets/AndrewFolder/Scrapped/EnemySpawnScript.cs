using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] EnemySpawnData speedEnemyData, rangedEnemyData, tankEnemyData;

    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] string winScene;

    List<GameObject> pooledObjects = new List<GameObject>();

    private void Start()
    {
        SetupLocalPool(speedEnemyData.enemyPrefab, speedEnemyData.numberOfEnemies);
        SetupLocalPool(rangedEnemyData.enemyPrefab, rangedEnemyData.numberOfEnemies);
        SetupLocalPool(tankEnemyData.enemyPrefab, tankEnemyData.numberOfEnemies);

        ActivateEnemiesAtSpawnPoints();
    }

    private void Update()
    {
        bool allEnemiesDestroyed = true;

        foreach (GameObject enemy in pooledObjects)
        {
            if (enemy != null && enemy.activeInHierarchy)
            {
                allEnemiesDestroyed = false;
                break;
            }
        }

        if (allEnemiesDestroyed)
        {
            SceneManager.LoadScene(winScene);
        }
    }

    private void SetupLocalPool(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    private void ActivateEnemiesAtSpawnPoints()
    {
        int spawnCount = Mathf.Min(spawnPoints.Count, pooledObjects.Count);

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject enemy = pooledObjects[i];

            if (!enemy.activeInHierarchy)
            {
                enemy.transform.SetPositionAndRotation(spawnPoints[i].position, spawnPoints[i].rotation);
                enemy.SetActive(true);
            }
        }
    }
}