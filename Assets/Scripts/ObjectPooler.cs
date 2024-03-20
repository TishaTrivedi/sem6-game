using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject; // Changed from "poolerdObject" to "pooledObject"
    public int pooledAmount;

    List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject); // Corrected the object creation
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++) // Changed from "pooledObjects.count" to "pooledObjects.Count"
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = Instantiate(pooledObject); // Corrected the object creation
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }

    // Removed the Update method as it was empty
}
