using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseScript : MonoBehaviour
{
    protected bool inAttackRange;
    protected bool inAlertRange;
    protected bool isAttacking;
    protected bool isPathSet;
    protected bool attackOnCooldown;

    public EnemyStateData enemyStateData;
    public EnemyStatsData enemyStatsData;

    public NavMeshAgent agent;
    protected Camera playerCam;
    private Vector3 setPath;
}