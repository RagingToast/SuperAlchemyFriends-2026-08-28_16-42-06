using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class RangeEnemy : EnemyBaseScript
{
    public Transform projectileSpawnPos;

    public float projectileActiveTime = 1f;

    public virtual void Attack()
    {
        if (attackOnCooldown)
        {
            return;
        }

        attackOnCooldown = true;
        isAttacking = true;

        transform.LookAt(new Vector3(playerCam.transform.position.x, transform.position.y, playerCam.transform.position.z));
        agent.SetDestination(transform.position);

        StartCoroutine(AttackTiming());
    }

    IEnumerator AttackTiming()
    {
        GameObject projectile = objectPool.GetObject();

        CollisionLogic collisionLogic = projectile.gameObject.GetComponent<CollisionLogic>();
        collisionLogic.projectileDamage = enemyStatsData.projectileDamage;
        collisionLogic.objectPool = objectPool;

        projectile.transform.SetPositionAndRotation(projectileSpawnPos.position, Quaternion.LookRotation(transform.forward));

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.linearVelocity = projectile.transform.forward * enemyStatsData.projectileSpeed;

        yield return StartCoroutine(DeactivatePrefab(projectile));

        attackOnCooldown = false;
        isAttacking = false;
    }

    IEnumerator DeactivatePrefab(GameObject projectile)
    {
        VisualEffect explode = projectile.GetComponent<VisualEffect>();

        yield return new WaitForSeconds(projectileActiveTime);

        objectPool.ReturnObject(projectile);
    }
}