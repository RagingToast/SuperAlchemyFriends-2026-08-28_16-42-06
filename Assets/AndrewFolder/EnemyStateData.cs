using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStateData", menuName = "Scriptable Objects/EnemyStateData")]
public class EnemyStateData : ScriptableObject
{
    public int attackRange;
    public int alertRange;
    public int wanderRange;

    public LayerMask whatIsPlayer;
}
