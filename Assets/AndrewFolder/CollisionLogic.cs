using UnityEngine;

public class CollisionLogic : MonoBehaviour
{
    public float projectileDamage;
    public ObjectPool objectPool;

    [SerializeField] string playerTag;
    [SerializeField] string enemyTag;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            PlayerHealth.Instance.TakeDamage(projectileDamage);
        }

        if (collision.gameObject.CompareTag(enemyTag))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            enemyHealth.TakeDamage(projectileDamage);
        }

        DeactivateOnImpact();
    }

    private void DeactivateOnImpact()
    {
        objectPool.ReturnObject(this.gameObject);
    }
}