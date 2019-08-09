using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public BatteryHealth bHealth;

    void Start()
    {
        
    }

    void Update()
    {
        
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
