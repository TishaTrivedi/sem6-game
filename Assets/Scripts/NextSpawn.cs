using System.Collections.Generic;
using UnityEngine;

public class NextSpawn : MonoBehaviour
{
    SpawnTown spawnTown;

    // Start is called before the first frame update
    void Start()
    {
        spawnTown = FindObjectOfType<SpawnTown>(); // Change FindObjectOfType<spawnTown>() to FindObjectOfType<SpawnTown>()
    }

    void OnTriggerExit(Collider other) // Change 'onTriggerExit' to 'OnTriggerExit' and 'collider' to 'Collider'
    {
        spawnTown.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

