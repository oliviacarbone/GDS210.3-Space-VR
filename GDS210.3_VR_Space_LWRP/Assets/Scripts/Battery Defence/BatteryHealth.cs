using UnityEngine;
using UnityEngine.UI;

public class BatteryHealth : MonoBehaviour
{
    public float batteryHealth;
    public float health;
    public EnemyController enemy;
    public Text healthText;

    public Image healthBar;

    void Start()
    {
        batteryHealth = 100f;
        health = batteryHealth;
    }

    void Update()
    {
        Lose();
        HealthColor();
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
            enemy.playerDead = true;
            enemy.dead = true;
            Destroy(gameObject);
        }
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
