using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonyResources : MonoBehaviour
{
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
    [Range(0,100)]
    public float water = 50.0f;
    [Range(0,100)]
    public float oxygen = 50.0f;
    //the population of the colony 
    public float population = 250f;
    //the rate at which the resource variables decay
    public float decayRate = 0.015f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrainResources();
        IncreaseResources();
        PopulationChanger();
        DecayRateChanger();
        
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
        if(water < 30f)
        {
            decayRate = 0.02f;
        }
        if(energy < 30f)
        {
            decayRate = 0.02f;
        }
        if(oxygen < 30f)
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

    void IncreaseResources()
    {
        if (Input.GetKeyUp("1"))
        {
            energy += 5f;
            water -= 2f;
            oxygen -= 1f;
        }
        if (Input.GetKeyUp("2"))
        {
            water += 6f;
            energy -= 3f;
            oxygen -= 2f;
        }
        if(Input.GetKeyUp("3"))
        {
            oxygen += 4f;
            water -= 4f;
            energy -= 1f;
        }
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
