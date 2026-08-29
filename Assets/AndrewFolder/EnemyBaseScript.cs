using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseScript : MonoBehaviour
{
    protected bool inAttackRange;
    protected bool inAlertRange;
    protected bool isAttacking;
    protected bool isPathSet;
    protected bool attackInCooldown;

    public EnemyStateData enemyStateData;
    public EnemyStatsData enemyStatsData;

    protected ObjectPool objectPool;
    public NavMeshAgent agent;
    protected Camera playerCam;
    private Vector3 setPath;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemyStatsData.speed;

        objectPool = GetComponent<ObjectPool>();
        objectPool.PoolSetup(enemyStatsData.projectilePrefab, enemyStatsData.projectileAmount);

        playerCam = PlayerMovement.Instance.GetComponentInChildren<Camera>();
    }

    public virtual void Update()
    {
        if (GetComponentInChildren<EnemyHealth>().isDead)
        {
            agent.enabled = false;
            return;
        }

        inAttackRange = Physics.CheckSphere(transform.position, enemyStateData.attackRange, enemyStateData.whatIsPlayer);
        inAlertRange = Physics.CheckSphere(transform.position, enemyStateData.alertRange, enemyStateData.whatIsPlayer);

        if (!inAlertRange)
        {
            Patrol();
        }
        else if (!inAttackRange && inAlertRange)
        {
            Chase();
        }
        else if (inAttackRange)
        {
            Attack();
        }
    }

    #region Patrol State
    public virtual void Patrol()
    {
        if (!isPathSet)
        {
            SetPatrolPath();
        }
        else if (isPathSet)
        {
            agent.SetDestination(setPath);
        }

        Vector3 distanceToSetPath = transform.position - setPath;

        if (distanceToSetPath.magnitude < 1f)
        {
            isPathSet = false;
        }
    }

    public virtual void SetPatrolPath()
    {
        int randomZ = Random.Range(-enemyStateData.wanderRange, enemyStateData.wanderRange);
        int randomX = Random.Range(-enemyStateData.wanderRange, enemyStateData.wanderRange);

        setPath = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        isPathSet = true;
    }
    #endregion

    #region Attack State
    private void Attack()
    {
        if (attackInCooldown)
        {
            return;
        }

        attackInCooldown = true;

        transform.LookAt(new Vector3(PlayerMovement.Instance.transform.position.x, transform.position.y, PlayerMovement.Instance.transform.position.z));

        agent.isStopped = true;
        agent.ResetPath();

        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        PlayerHealth.Instance.TakeDamage(enemyStatsData.damage);

        yield return new WaitForSeconds(enemyStatsData.attackRate);

        attackInCooldown = false;
    }
    #endregion

    #region Chase State
    public virtual void Chase()
    {
        Vector3 targetPos = new Vector3(PlayerMovement.Instance.transform.position.x, transform.position.y, PlayerMovement.Instance.transform.position.z);
        agent.SetDestination(targetPos);
    }
    #endregion
}