using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

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

    public float timeBetweenWaves = 5f;
    private float waveCountDown = 0f;

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
    }

    void WaveCompleted()
    {
        Debug.Log("Wave done");
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves done, Looping");
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
            if (GameObject.FindGameObjectWithTag("Water") == null)
            {
                return false;
            }
            if (GameObject.FindGameObjectWithTag("Energy") == null)
            {
                return false;
            }
            if (GameObject.FindGameObjectWithTag("Oxygen") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
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
        Debug.Log("Spawning Enemy: ");
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(interactable, _sp.position, _sp.rotation);
        
    }


}
