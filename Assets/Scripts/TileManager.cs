using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefab;
    private Transform playerTransform;

    private float spawnZ = 0.0f;
    private float tileLength = 290.0f;
    private int amnTilesOnScreen = 7;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform != null)
        {
            SpawnTile(0);
            SpawnTile(0);
            SpawnTile(0);
            SpawnTile(0);
        }
        else
        {
            UnityEngine.Debug.LogError("Player GameObject not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefab[0]);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
    }
}
