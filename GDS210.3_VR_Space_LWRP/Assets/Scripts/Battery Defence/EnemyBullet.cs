using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private BatteryHealth bHealth;

    void Awake()
    {
        bHealth = FindObjectOfType<BatteryHealth>();
    }

    //Destroys the bullet when it hits the battery
    private void OnTriggerEnter(Collider other)
    {
        bHealth.Damage();

        if (other.CompareTag("Battery"))
        {
            Destroy(gameObject);
        }
    }
}
