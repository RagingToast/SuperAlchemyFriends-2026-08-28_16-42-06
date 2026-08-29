using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyStatsData enemyStatsData;
    [SerializeField] float currentHP;
    private float minHP = 0f;
    public bool isDead;

    void Start()
    {
        float maxHP = enemyStatsData.health;
        currentHP = maxHP;
    }

    public float TakeDamage(float damageValue)
    {
        currentHP -= damageValue;

        Death();

        return currentHP;
    }

    private void Death()
    {
        if (isDead)
        {
            return;
        }

        if (currentHP <= minHP)
        {
            isDead = true;

            transform.gameObject.SetActive(false);
        }
    }
}