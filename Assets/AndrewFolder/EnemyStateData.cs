using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStateData", menuName = "Scriptable Objects/EnemyStateData")]
public class EnemyStateData : ScriptableObject
{
    public float attackRange;
    public float alertRange;
    public float wanderRange;

    public LayerMask whatIsPlayer;
}
