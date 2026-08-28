using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnData", menuName = "Scriptable Objects/EnemySpawnData")]
public class EnemySpawnData : ScriptableObject
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;
}
