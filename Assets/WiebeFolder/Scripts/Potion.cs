using System.Collections;
using UnityEngine;

public class Potion : MonoBehaviour
{
    
    public AudioSource audioSource;
    void OnCollisionEnter(Collision collision)
    {
        PotionEffect.instance.SpawnPotionNucleus(transform.position);
        audioSource.PlayOneShot(audioSource.clip);
        Destroy(gameObject);
    }

    
}
