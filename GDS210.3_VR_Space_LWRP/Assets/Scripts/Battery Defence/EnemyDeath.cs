using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField]
    Renderer renderColor;

    public Gun playerGun;
    public float enemyHealth;


    void Start()
    {
        enemyHealth = 100;
    }

    private void Update()
    {
        //enemyHealth = enemyHealth - 1f;

        Death();
    }

    public void Hit()
    {
        //Turns test drown red if hit 
        //renderColor.material.color = Color.red;

        //Calls ChangeColor() after 2 seconds
        //Invoke("ChangeColor", 2);
        Debug.Log("Hit Registered");
        Damage();
    }

    void ChangeColor()
    {
        //Turns Test drone back to white
        //renderColor.material.color = Color.white;
    }

    void Damage()
    {
        
        //Damages enemy 
        enemyHealth = enemyHealth - 50f; //playerGun.playerDamage;

        Debug.Log("Target Damaged");
    }


    void Death()
    {
        //Destroys the enemy when health reaches 0

        
        if(enemyHealth <= 0f)
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
            
    }
}
