using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemySpawnList;
    [SerializeField] private TextMeshProUGUI roundText;
    
    private GameObject _spawnArea;
    
    public Queue<GameObject> enemyPool = new Queue<GameObject>();
    public List<GameObject> enemyPrefab;
    
    public static EnemySpawner instance;

    private int _currentRound = 1;
    private int _enemiesToSpawn= 10;
    private int _enemiesSpawned = 0;
    private bool _canSpawn = true;

    public int enemiesAlive = 0;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        roundText.text = $"Round {_currentRound}";
    }
    
    public GameObject GetObject()
    {
        GameObject obj;

        if (enemyPool.Count > 0)
        {
            obj = enemyPool.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            int i = Random.Range(0, enemyPrefab.Count);
            obj = Instantiate(enemyPrefab[i]);
        }

        obj.transform.position = _spawnArea.transform.position;
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        enemyPool.Enqueue(obj);
    }
    
    // IEnumerator Spawn()
    // {
    //     //Spawns enemies randomly at one of the 3 spawn points
    //     int i = Random.Range(0, enemySpawnList.Count);
    //     _spawnArea = enemySpawnList[i].transform;
    //
    //     _enemiesSpawned = 0;
    //
    //     while (_enemiesSpawned < _enemiesToSpawn)
    //     {
    //         GetObject();
    //         _enemiesSpawned++;
    //         enemiesAlive++;
    //
    //         yield return new WaitForSeconds(1f);
    //     }
    //
    //     yield return new WaitUntil(() => enemiesAlive == 0);
    //     yield return new WaitForSeconds(4f);
    //     
    //     RoundUp();
    //     StartCoroutine(Spawn());
    //
    // }
    IEnumerator Spawn()
    {
        _enemiesSpawned = 0;

        while (_enemiesSpawned < _enemiesToSpawn)
        {
            foreach (GameObject spawnPoint in enemySpawnList)
            {
                if (_enemiesSpawned >= _enemiesToSpawn)
                    break;

                _spawnArea = spawnPoint;
                GetObject();

                _enemiesSpawned++;
                enemiesAlive++;

                yield return new WaitForSeconds(1f);
            }
        }

        yield return new WaitUntil(() => enemiesAlive == 0);
        yield return new WaitForSeconds(4f);

        RoundUp();
        StartCoroutine(Spawn());
    }
    
    //logic that fires when the round is increased
    void RoundUp()
    {
        _currentRound += 1;
        _enemiesToSpawn += 10;
        _enemiesSpawned = 0;
        enemiesAlive = 0;
    }
}

//Unused code but is kept for reference

// if (enemyPool.Count > 0)
// {
//     // GameObject obj = enemyPool.Dequeue();
//     // obj.SetActive(true);
//     // return obj;
// }
// return Instantiate(enemyPrefab, _spawnArea.position, Quaternion.identity);