using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public ColonyResources colResSpawner;

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

   [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform spawnResource;
        public int count;
        public float spawnRate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] resources;
    public Transform[] spawnPoints;

    public float timeBetweenWaves = 0.5f;
    public float waveCountDown = 0f;

    private float searchCountDown = 1f;
         
    private SpawnState state = SpawnState.COUNTING;

     void Start()
    {
        waveCountDown = timeBetweenWaves;
    }
    void Update()
    {
        
        if (state == SpawnState.WAITING)
        {
            if (!InteractableisAlive())
            {
                WaveCompleted();
                
            }
            else
            {
                return;
            }
        }
        if (waveCountDown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
       // FailSafeSpawn();
    }
   /* public void FailSafeSpawn()
    {
        Transform spawnPointFailSafe = spawnPoints[Random.Range(0, spawnPoints.Length)];
        if (colResSpawner.energy < 25f)
        {
            Debug.Log("Failsafe energy");
            Instantiate(resources[2], spawnPointFailSafe.position, spawnPointFailSafe.rotation);
        }
        if (colResSpawner.water < 25f)
        {
            Debug.Log("Failsafe water");
            Instantiate(resources[0], spawnPointFailSafe.position, spawnPointFailSafe.rotation);
        }
        if (colResSpawner.oxygen < 25f)
        {
            Debug.Log("Failsafe oxygen");
            Instantiate(resources[1], spawnPointFailSafe.position, spawnPointFailSafe.rotation);
        }


    }*/

    void WaveCompleted()
    {
        
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            
        }
        else
        {
            nextWave++;
        }
    }




    bool InteractableisAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
           
        }
        return false;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnInteractable(resources[Random.Range(0, resources.Length)]);
            yield return new WaitForSeconds(1f/_wave.spawnRate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnInteractable(Transform interactable)
    {
        
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(interactable, _sp.position, _sp.rotation);
        
    }


}
