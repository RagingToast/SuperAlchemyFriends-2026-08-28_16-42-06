using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatsData", menuName = "Scriptable Objects/EnemyStatsData")]
public class EnemyStatsData : ScriptableObject
{
    public float damage;
    public float health;
    public float speed;
    public float attackRate;

    public float projectileDamage;
    public float projectileSpeed;
}