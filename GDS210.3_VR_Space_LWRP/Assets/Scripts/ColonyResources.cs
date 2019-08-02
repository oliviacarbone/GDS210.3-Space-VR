using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColonyResources : MonoBehaviour
{
    
    public StartColonyGame startColGame;
    public bool gameOver = false;
    public GameObject gameOverText;
    
    // Resource Variables
    [SerializeField]
    private float energyPrivate;
    public float energy
    {
        set
        {

            if (value < 0f)
            {
                energyPrivate = 0f;
            }
            else if (value > 100f)
            {
                energyPrivate = 100f;
            }
            else
            {
                energyPrivate = value;
            }
        }
        get { return energyPrivate; }
    }
    [SerializeField]
    private float waterPrivate;
    public float water
    {
        set
        {
            if (value < 0f)
            {
                waterPrivate = 0f;
            }
            else if (value > 100f)
            {
                waterPrivate = 100f;
            }
            else
            {
                waterPrivate = value;
            }
        }
        get { return waterPrivate; }
    }
    [SerializeField]
    private float oxygenPrivate;
    public float oxygen
    {
        set
        {
            if (value < 0f)
            {
                oxygenPrivate = 0f;
            }
            else if (value > 100f)
            {
                oxygenPrivate = 100f;
            }
            else
            {
                oxygenPrivate = value;
            }
        }
        get { return oxygenPrivate; }
    }
    //the population of the colony 
    [SerializeField]
    private float populationPrivate;
    public float population
    {
        set
        {
            if (value < 0f)
            {
                populationPrivate = 0f;
            }
            else
            {
                populationPrivate = value;
            }
        }
        get { return populationPrivate; }
    }
    //the rate at which the resource variables decay
    public float decayRate = 0.015f;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        energy = 50f;
        water = 50f;
        oxygen = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false && startColGame.startGame == true)
        {
            DrainResources();


            PopulationChanger();
            DecayRateChanger();
        }

        if (energy == 0f || water == 0f || oxygen == 0f)
        {
            gameOverText.SetActive(true);
            gameOver = true;
            
        }
        else { gameOver = false; }
    }

  


    //if population reaches set levels the decayRate variable will increase/decrease
    void DecayRateChanger()
    {
        if (population < 100f)
        {
            decayRate = 0.01f;
        }
        if (population > 500f)
        {
            decayRate = 0.02f;
        }
        if (population == 101f || population == 499f)
        {
            decayRate = 0.015f;
        }
        if (water < 30f)
        {
            decayRate = 0.02f;
        }
        if (energy < 30f)
        {
            decayRate = 0.02f;
        }
        if (oxygen < 30f)
        {
            decayRate = 0.02f;
        }

    }

    void DrainResources()
    {
        energy -= decayRate;
        water -= decayRate;
        oxygen -= decayRate;
    }

    public void IncreaseEnergy()
    {
            energy += 5f;
            water -= 0f;
            oxygen -= 0f;
    }
    public void IncreaseWater()
    {
        water += 6f;
        energy -= 0f;
        oxygen -= 0f;
    }
    public void IncreaseOxygen()
    {
        oxygen += 4f;
        water -= 0f;
        energy -= 0f;
    }

    //if water goes below/above a set point decrease or increase population respectively
    void PopulationChanger()
    {
        if (water < 25f && energy < 25f && oxygen < 25f)
        {
            population -= 0.5f;
        }
        if (water > 75f && energy > 75f && oxygen > 75f)
        {
            population += 0.5f;
        }
    }

}
