using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField]
    Material droneColour;

    public Gun playerGun;
    public EnemyController enemyController;
    public EnemyShooting enemyShooting;
    public float enemyHealth;
    public bool enemyDeathTest = true;
    public float force;


    void Start()
    {
        enemyHealth = 100;
        //droneColour.color = Color.white;
        ChangeColor();             
    }

    void Update()
    {
        if(enemyHealth <= 100)
        {
            Fall();
        }
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
    }

    void Damage()
    {        
        //Damages enemy 
        enemyHealth = enemyHealth - 50f; 
        Debug.Log("Target Damaged");
    }

    void Fall()
    {
        //Destroys the enemy when health reaches 0        
        if(enemyDeathTest == true) //enemyHealth <= 0f)   
        {
            enemyController.ReturnPoint();
            enemyController.agent.enabled = false;
            GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
            enemyController.dead = true;
            enemyShooting.shooting = false;            
            Invoke("Death", 5);
            enemyDeathTest = false;
        }            
    }

    void Death()
    {
        Debug.Log("Drone Destroyed");
        Destroy(gameObject);
    }
}
