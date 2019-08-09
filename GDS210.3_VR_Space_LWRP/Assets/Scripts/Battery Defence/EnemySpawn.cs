using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemySpawner;
    public GameObject enemy;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        
    }

    void Spawn()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(enemy, enemySpawner.transform.position, Quaternion.identity);
        }
    }
}
