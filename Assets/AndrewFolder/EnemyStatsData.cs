using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatsData", menuName = "Scriptable Objects/EnemyStatsData")]
public class EnemyStatsData : ScriptableObject
{
    public float damage;
    public float attackRate;
    public float speed;
}