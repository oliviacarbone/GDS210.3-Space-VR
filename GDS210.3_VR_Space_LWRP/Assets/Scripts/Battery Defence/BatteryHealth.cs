using UnityEngine;

public class BatteryHealth : MonoBehaviour
{
    public float batteryHealth;
    private EnemyController enemy;

    void Awake()
    {
        enemy = FindObjectOfType<EnemyController>();    
    }

    void Start()
    {
        batteryHealth = 100f;
    }

    public void Damage()
    {
        batteryHealth = batteryHealth - enemy.enemyDamage;
    }

    void Lose()
    {
        if (batteryHealth <= 0f)
            Destroy(gameObject);
    }
}
