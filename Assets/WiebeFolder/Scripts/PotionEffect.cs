using System.Collections;
using UnityEngine;

public class PotionEffect : MonoBehaviour
{
    [SerializeField] private GameObject potionNucleus;
    
    // public float projectileDamage;

    // private GameObject _currentNucleus;
    
    private float _potionRadius = 1.5f;
    
    public static PotionEffect instance;

    void Awake()
    {
        instance = this;
    }
    
    public void SpawnPotionNucleus(Vector3 position)
    {
        Debug.Log("Spawning potion nucleus");
        
        GameObject currentNucleus = Instantiate (potionNucleus, position, Quaternion.identity);
        
        PotionZone(position);
        
        StartCoroutine(DespawnPotionNucleus(currentNucleus));
    }

    void PotionZone(Vector3 position)
    {
        Debug.Log("Layer mask: " + PotionStates.instance.enemyLayer.value);
        
        Collider[] colliders = Physics.OverlapSphere(position, _potionRadius, PotionStates.instance.enemyLayer);
        
        Debug.Log("Found: " + colliders.Length);
        
        foreach (Collider col in colliders)
        {
            EnemyBase enemyHealth = col.gameObject.GetComponent<EnemyBase>();

            enemyHealth.TakeDamage();
        }
    }
    
    IEnumerator DespawnPotionNucleus(GameObject currentNucleus)
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Despawn Potion Nucleus");
        Destroy(currentNucleus);
    }
}
