using UnityEngine;

public class BatteryHealth : MonoBehaviour
{
    public float batteryHealth;
    public EnemyController enemy;

    void Awake()
    {
        //enemy = FindObjectOfType<EnemyController>();    
    }

    void Start()
    {
        batteryHealth = 100f;
    }

    void Update()
    {
        Lose();    
    }

    public void Damage()
    {
        batteryHealth = batteryHealth - enemy.enemyDamage;
        print(enemy.enemyDamage);
    }

    void Lose()
    {
        if (batteryHealth <= 0f)
            Destroy(gameObject);
    }
}
