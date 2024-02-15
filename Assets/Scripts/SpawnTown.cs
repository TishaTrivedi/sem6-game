using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTown : MonoBehaviour
{
    [SerializeField] GameObject groundTile;

    Vector3 nextSpawnerPoint;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnerPoint, Quaternion.identity);
        nextSpawnerPoint = temp.transform.GetChild(2).transform.position;
            
            }
    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i < 3; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
