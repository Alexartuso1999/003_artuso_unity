using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnTime = 2f;

    float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnTime)
        {
        Instantiate(prefabToSpawn, Vector3.one, Quaternion.identity, transform);
            spawnTimer = 0;
        }
    }
}
