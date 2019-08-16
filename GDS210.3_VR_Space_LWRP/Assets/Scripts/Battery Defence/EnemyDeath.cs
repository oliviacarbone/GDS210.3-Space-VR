using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField]
    Material droneColour;

    public Gun playerGun;
    public EnemyController enemyController;
    public EnemyShooting enemyShooting;
    public float enemyHealth;


    void Start()
    {
        enemyHealth = 100;
        //droneColour.color = Color.white;
        ChangeColor();             
    }

    void Update()
    {
        Fall();
    }

    public void Hit()
    {
        //Turns test drown red if hit 
        //droneColour.color = Color.red;

        //Calls ChangeColor() after 2 seconds
        Invoke("ChangeColor", 2);
        Debug.Log("Hit Registered");
        Damage();
    }

    void ChangeColor()
    {
        //Turns Test drone back to white

        droneColour.color = Color.red;

        //foreach(Material m in )
    
        
    }

    void Damage()
    {        
        //Damages enemy 
        enemyHealth = enemyHealth - 50f; //playerGun.playerDamage;
        Debug.Log("Target Damaged");
    }


    void Fall()
    {
        //Destroys the enemy when health reaches 0        
        if(enemyHealth <= 0f)
        {
            enemyController.agent.enabled = false;
            enemyController.ReturnPoint();
            enemyShooting.shooting = false;
            Invoke("Death", 5);
        }            
    }

    void Death()
    {
        Debug.Log("Destroyed");
        Destroy(gameObject);
    }
}
