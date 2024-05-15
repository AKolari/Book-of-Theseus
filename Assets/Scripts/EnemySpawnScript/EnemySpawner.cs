using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnDelay, lastSpawnTime;
    public GameObject[] enemy;

    public float totEnemies;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
        spawnDelay = 1.5f;

        totEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSpawnTime >= spawnDelay)
        {
            if (totEnemies < 2)
            {
                int spawnSpot = (int)Random.Range(0, spawnPoints.Length);
                Transform theSpot = spawnPoints[spawnSpot];
                Instantiate(enemy[Random.Range(0, enemy.Length)], theSpot.transform.position, Quaternion.identity);
                lastSpawnTime = Time.time;

                totEnemies++;
            }
        }
    }
}
