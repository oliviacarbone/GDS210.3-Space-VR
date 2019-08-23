using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    //startColGame is required for the defense game aswell, it just puts in a button mechanic to start the game
    public StartColonyGame startColGame;
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

    public float timeBetweenWaves = 10f;
    private float waveCountDown = 0f;

    private float searchCountDown = 1f;

    private float failSafeCountDownEnergy = 15f;
    private float failSafeCountDownOxygen = 15f;
    private float failSafeCountDownWater = 15f;


    private SpawnState state = SpawnState.COUNTING;

     void Start()
    {
        timeBetweenWaves = 2f;
        failSafeCountDownEnergy = 5f;
        failSafeCountDownOxygen = 5f;
        failSafeCountDownWater = 5f;
        waveCountDown = timeBetweenWaves;
    }

    void Update()
    {
        if (colResSpawner.restartGame == true && colResSpawner.gameOver == false)
        {
            failSafeCountDownWater -= Time.deltaTime;
            failSafeCountDownOxygen -= Time.deltaTime;
            failSafeCountDownEnergy -= Time.deltaTime;

            if (state == SpawnState.WAITING)
            {
                if (!InteractableisAlive())
                {

                    WaveCompleted();
                    FailSafeSpawnEnergy();
                    FailSafeSpawnOxygen();
                    FailSafeSpawnWater();
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
    }
   public void FailSafeSpawnEnergy()
    {
        Transform spawnPointFailSafeEnergy = spawnPoints[1];
        if (failSafeCountDownEnergy <= 0f) {
            if (colResSpawner.energy < 30f)
            {
                


                Instantiate(resources[2], spawnPointFailSafeEnergy.position, spawnPointFailSafeEnergy.rotation);
            }
            failSafeCountDownEnergy = 5f;
        }
        
    }
    public void FailSafeSpawnOxygen()
    {
        Transform spawnPointFailSafeOxygen = spawnPoints[2];
        if (failSafeCountDownOxygen <= 0f)
        {
            if (colResSpawner.oxygen < 30f)
            {
                
                Instantiate(resources[1], spawnPointFailSafeOxygen.position, spawnPointFailSafeOxygen.rotation);
            }
            failSafeCountDownOxygen = 5f;
        }
    }
    public void FailSafeSpawnWater()
    {
        Transform spawnPointFailSafeWater = spawnPoints[3];
        if (failSafeCountDownWater <= 0f)
        {
            if (colResSpawner.water < 30f)
            {
                
                Instantiate(resources[0], spawnPointFailSafeWater.position, spawnPointFailSafeWater.rotation);
            }
            failSafeCountDownWater = 5f;
        }
    }

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



    //modified bool to put a slight second between starting a new wave
    bool InteractableisAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 0.5f;
            if (GameObject.FindGameObjectWithTag("Interactable") == null)
            {
               
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        if (colResSpawner.restartGame == true) { 
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnInteractable(resources[Random.Range(0, resources.Length)]);
            yield return new WaitForSeconds(1f / _wave.spawnRate);
        }

        state = SpawnState.WAITING;
    }
        yield break;
    }

    void SpawnInteractable(Transform interactable)
    {
        
        Transform _sp = spawnPoints[0];
        Instantiate(interactable, _sp.position, _sp.rotation);
        
    }


}
