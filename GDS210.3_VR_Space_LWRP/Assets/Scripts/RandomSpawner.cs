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
        public Transform spawnLocal;
        public int count;
        public float spawnRate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown = 0f;

    private SpawnState state = SpawnState.COUNTING;

     void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {

        }
        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnInteractable(_wave.spawnLocal);
            yield return new WaitForSeconds(1f/_wave.count);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnInteractable(Transform interactable)
    {
        Debug.Log("spawning enemy: " + interactable);
    }


}
