using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;


    // Start is called before the first frame update
    void Start()
    {
        spawnObjects();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY,screenZ;
        Vector3 pos;

        for(int i = 0; i<numberToSpawn; i++)
        {
            randomItem = UnityEngine.Random.Range(0,spawnPool.Count);
            toSpawn= spawnPool[randomItem];

            screenX = UnityEngine.Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = UnityEngine.Random.Range(c.bounds.min.y, c.bounds.max.y);
            screenZ = UnityEngine.Random.Range(c.bounds.min.z, c.bounds.max.z);

            pos = new Vector3(screenZ,screenX,screenY); 

            Instantiate(toSpawn, pos,Quaternion.identity);
        }
    }
}
