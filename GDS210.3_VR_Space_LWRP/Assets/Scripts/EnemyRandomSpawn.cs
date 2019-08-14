﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRandomSpawn : MonoBehaviour
{
    //Setting up the function to control the enemy spawning.
    public enum SpawnState { Spawning, Waiting, Countdown };
    public SpawnState state = SpawnState.Countdown;

    //Setting up how each wave will work and how many we will spawn.
    [System.Serializable]
    public class EnemyWave
    {
        public string name;
        public Transform[] spawnEnemyShip;
        public int count;
        public float rate;
    }

    public EnemyWave[] waves;
    private int nextWave = 0;
    public int waveNumber = 0;

    //The time it will take for the wave to end and then go to new wave.
    public float enemySpawnDelay;
    public float enemySpawnCountDown;
    //This is to help search to make sure that all the enemy are gone in the scene.
    public float searchCountDown = 1f;

    //This is so that the enem y can spawn in random locations.
    public Transform[] enemyShipSpawnPoint;

    public Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnCountDown = enemySpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case (SpawnState.Countdown):
                NewWave();
                break;
            case (SpawnState.Spawning):
                if (enemySpawnCountDown <= 0)
                {
                    StartCoroutine(SpawningEnemyShip(waves[nextWave]));
                }
                else
                {
                    enemySpawnCountDown -= Time.deltaTime;
                }
                break;
            case (SpawnState.Waiting):
                if (!EnemyIsAlive())
                {
                    state = SpawnState.Countdown;
                    return;
                }
                break;
        }

        waveText.text = waveNumber.ToString();

    }

    //Making sure that the enemy is dead before starting up the next wave.
    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("EnemyShip").Length == 0)
            {
                return false;
            }
        }

        return true;
    }

    //Once all the enemy is gone, then it will set up for new wave.
    void NewWave()
    {
        enemySpawnCountDown = enemySpawnDelay;

        if (nextWave + 1 > waves.Length - 1)
        {
            //This is where the game will end. Need help for this please.
            Debug.Log("All enemy have been defeated. Game is done!");
        }
        else
        {
            nextWave++;
            waveNumber++;
            state = SpawnState.Spawning;
        }
    }

    //To setup the position and how many we will be spawning.
    IEnumerator SpawningEnemyShip(EnemyWave wave)
    {
        for (int i = 0; i < wave.count; i++)
        {
            EnemyWave enemyShip = waves[i];

            SpawnEnemyShip(enemyShip.spawnEnemyShip[Random.Range(0, enemyShip.spawnEnemyShip.Length)]);
            yield return new WaitForSeconds(1f / wave.rate);
            SpawnEnemyShip(enemyShip.spawnEnemyShip[Random.Range(0, enemyShip.spawnEnemyShip.Length)]);
            yield return new WaitForSeconds(2f / wave.rate);
            SpawnEnemyShip(enemyShip.spawnEnemyShip[Random.Range(0, enemyShip.spawnEnemyShip.Length)]);
            yield return new WaitForSeconds(3f / wave.rate);
            SpawnEnemyShip(enemyShip.spawnEnemyShip[Random.Range(0, enemyShip.spawnEnemyShip.Length)]);
            yield return new WaitForSeconds(4f / wave.rate);
        }

        state = SpawnState.Waiting;
        yield break;
    }

    //Spawn the enemy ship now.
    void SpawnEnemyShip(Transform enemy)
    {
        Transform spawnPoint = enemyShipSpawnPoint[Random.Range(0, enemyShipSpawnPoint.Length)];
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
