using System.Collections;
using UnityEngine;

public class Potion : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        PotionEffect.instance.SpawnPotionNucleus(transform.position);
        Destroy(gameObject);
        
    }

    
}
