﻿using UnityEngine;
using UnityEngine.UI;

public class BatteryHealth : MonoBehaviour
{
    public float batteryHealth;
    public float health;
    public EnemyController enemy;
    public Text healthText;

    public EnemyRandomSpawn spawnState;
    public ScoreScript1 endTheGame;

    public Image healthBar;
    public ParticleSystem loseExpl;
    public GameObject battery;
    private bool batteryDead;

    private void Awake()
    {
        spawnState = FindObjectOfType<EnemyRandomSpawn>();
        endTheGame = FindObjectOfType<ScoreScript1>();
    }

    void Start()
    {
        batteryHealth = 100f;
        health = batteryHealth;
        batteryDead = false;
    }

    void Update()
    {
        enemy = FindObjectOfType<EnemyController>(); 

        HealthColor();
        if (batteryDead == true)
            return;
        Lose();
    }

    public void Damage()
    {
        batteryHealth = batteryHealth - enemy.enemyDamage;
        healthBar.fillAmount = batteryHealth / 100;
        healthText.text = batteryHealth.ToString("F0") + "%";
        //print(enemy.enemyDamage);
    }

    void Lose()
    {
        if (batteryHealth <= 0f)
        {
            //enemy.dead = true;
            spawnState.state = EnemyRandomSpawn.SpawnState.GameIsOver;
            battery.SetActive(false);
            FindObjectOfType<AudioManager>().Play("BD_BatteryDeath");
            loseExpl.Play(true);
            enemy.playerDead = true;
            enemy.dead = true;
            endTheGame.gameIsOver = true;
            batteryDead = true;
            Invoke("DestroyBattery", 3);
        }
    }

    void DestroyBattery()
    {
        Destroy(gameObject);
    }

    void HealthColor()
    {
        if(batteryHealth <= 50f)
        {
            healthText.color = Color.yellow;
        }

        if (batteryHealth <= 25f)
        {
            healthText.color = Color.red;
        }
    }
}
