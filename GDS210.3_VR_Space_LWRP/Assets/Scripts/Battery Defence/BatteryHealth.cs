using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryHealth : MonoBehaviour
{
    public float batteryHealth;
    public EnemyController enemy;

    void Start()
    {
        batteryHealth = 100f;
    }

    void Update()
    {

    }

    void Damage()
    {
        batteryHealth = batteryHealth - enemy.enemyDamage;
    }

    void Lose()
    {
        if (batteryHealth <= 0f)
            Destroy(gameObject);
    }
}
