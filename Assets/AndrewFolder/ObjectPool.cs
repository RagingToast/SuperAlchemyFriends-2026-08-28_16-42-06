using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Queue<GameObject> objectQueue = new Queue<GameObject>();

    public void PoolSetup(GameObject prefabToInstantiate, int amountToPool)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject prefab = Instantiate(prefabToInstantiate);
            prefab.SetActive(false);
            objectQueue.Enqueue(prefab);
        }
    }

    public GameObject GetObject()
    {
        if (objectQueue.Count > 0)
        {
            GameObject obj = objectQueue.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        
        return null;
    }

    public void ReturnObject(GameObject prefab)
    {
        prefab.SetActive(false);
        objectQueue.Enqueue(prefab);
    }
}