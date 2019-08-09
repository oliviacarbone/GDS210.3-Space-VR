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

    void Update()
    {
        Damage();
        Death();
    }

    public void Hit()
    {
        //Turns test drown red if hit 
        renderColor.material.color = Color.red;

        //Calls ChangeColor() after 2 seconds
        Invoke("ChangeColor", 2);
    }

    void ChangeColor()
    {
        //Turns Test drone back to white
        renderColor.material.color = Color.white;
    }

    void Damage()
    {
        //Damages enemy 
        enemyHealth = enemyHealth - playerGun.playerDamage;
    }


    void Death()
    {
        //Destroys the enemy when health reaches 0
        if(enemyHealth <= 0f)
            Destroy(gameObject);
    }
}
