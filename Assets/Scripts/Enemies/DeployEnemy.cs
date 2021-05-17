using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployEnemy : MonoBehaviour
{
    private float nextSpawnTime;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private float spawnDelay = 10;

    public float respawnTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn()) {
            Spawn();
        }
    }

    void Spawn()
    {
     nextSpawnTime = Time.time + spawnDelay;
        Instantiate(EnemyPrefab, transform.position, transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
