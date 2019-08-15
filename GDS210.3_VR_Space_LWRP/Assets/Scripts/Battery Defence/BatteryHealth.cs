using UnityEngine;
using UnityEngine.UI;

public class BatteryHealth : MonoBehaviour
{
    public float batteryHealth;
    public float health;
    public EnemyController enemy;

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
        //print(enemy.enemyDamage);
    }

    void Lose()
    {
        if (batteryHealth <= 0f)
            Destroy(gameObject);
    }

    void HealthColor()
    {
        if(batteryHealth <= 50f)
        {
            healthBar.GetComponent<Image>().color = Color.yellow;
        }

        if (batteryHealth <= 25f)
        {
            healthBar.color = Color.red;
        }
    }
}
