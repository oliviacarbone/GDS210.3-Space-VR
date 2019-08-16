using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColonyResources : MonoBehaviour
{
    public ScoreScript colonyScore;
    public StartColonyGame startColGame;
    public bool restartGame = false;
    public bool gameOver = false;
    public GameObject youLoseText;
    public GameObject youWinText;
    public GameObject startGameText;
    public Slider energySlider;
    public Slider waterSlider;
    public Slider oxygenSlider;
    public Text populationCount;
    public GameObject energyText;
    public GameObject waterText;
    public GameObject oxygenText;
    public GameObject populationText1;
    public GameObject populationText2;

    //To call the time script in order to end the game once the games 0
    public TimeScript timer;

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
        youLoseText.SetActive(false);
        youWinText.SetActive(false);
        startGameText.SetActive(true);
        energySlider.gameObject.SetActive(false);
        waterSlider.gameObject.SetActive(false);
        oxygenSlider.gameObject.SetActive(false);
        populationCount.gameObject.SetActive(false);
        energyText.SetActive(false);
        waterText.SetActive(false);
        oxygenText.SetActive(false);
        populationText1.SetActive(false);
        populationText2.SetActive(false);
        energy = 50f;
        water = 50f;
        oxygen = 50f;
        population = 0f;
        timer.second = 0;
        timer.minute = 2;
    }
    public int newPop;

    // Update is called once per frame
    void Update()
    {
        newPop = (int)population;
        colonyScore.currentScore = newPop;
        if (startColGame.startGame == true)
        {
            youLoseText.SetActive(false);
            youWinText.SetActive(false);
            startGameText.SetActive(false);
            energy = 50f;
            water = 50f;
            oxygen = 50f;
            population = 0f;
            restartGame = true;
            startColGame.startGame = false;
            energySlider.gameObject.SetActive(true);
            waterSlider.gameObject.SetActive(true);
            oxygenSlider.gameObject.SetActive(true);
            populationCount.gameObject.SetActive(true);
            energyText.SetActive(true);
            waterText.SetActive(true);
            oxygenText.SetActive(true);
            populationText1.SetActive(true);
            populationText2.SetActive(true);
            
        }
        if (gameOver == false && restartGame == true)
        {
            DrainResources();


            PopulationChanger();
            DecayRateChanger();
        }

        if (energy <= 0f || water <= 0f || oxygen <= 0f)
        {
            youLoseText.SetActive(true);
            youWinText.SetActive(false);
            startGameText.SetActive(false);
            gameOver = true;
            restartGame = false;
            energySlider.gameObject.SetActive(false);
            waterSlider.gameObject.SetActive(false);
            oxygenSlider.gameObject.SetActive(false);
            populationCount.gameObject.SetActive(false);
            energyText.SetActive(false);
            waterText.SetActive(false);
            oxygenText.SetActive(false);
            populationText1.SetActive(false);
            populationText2.SetActive(false);
            timer.state = TimeScript.TimeState.DoNothing;
            colonyScore.gameIsOver = true;
            startColGame.state = StartColonyGame.ButtonState.Start;

        }
        else { gameOver = false; }

        if (timer.minute == 0 && timer.second == 0)
        {
            youLoseText.SetActive(false);
            youWinText.SetActive(true);
            startGameText.SetActive(false);
            gameOver = true;
            restartGame = false;
            energySlider.gameObject.SetActive(false);
            waterSlider.gameObject.SetActive(false);
            oxygenSlider.gameObject.SetActive(false);
            populationCount.gameObject.SetActive(false);
            energyText.SetActive(false);
            waterText.SetActive(false);
            oxygenText.SetActive(false);
            populationText1.SetActive(false);
            populationText2.SetActive(false);
            timer.state = TimeScript.TimeState.DoNothing;
            colonyScore.gameIsOver = true;
            startColGame.state = StartColonyGame.ButtonState.Start;
        }
        else
        {
            gameOver = false;
        }

        energySlider.value = energy;
        waterSlider.value = water;
        oxygenSlider.value = oxygen;
        populationCount.text = population.ToString("00");
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
            energy += 10f;
            water -= 0f;
            oxygen -= 0f;
    }
    public void IncreaseWater()
    {
        water += 10f;
        energy -= 0f;
        oxygen -= 0f;
    }
    public void IncreaseOxygen()
    {
        oxygen += 10f;
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
