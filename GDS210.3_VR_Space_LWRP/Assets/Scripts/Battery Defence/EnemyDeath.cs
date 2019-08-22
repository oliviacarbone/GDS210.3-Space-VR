using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Gun playerGun;
    public EnemyController enemyController;
    public EnemyShooting enemyShooting;
    public float enemyHealth = 100;
    public bool enemyDeathTest;
    public float force;
    public float rotForce;
    private Rigidbody rb;
    public ParticleSystem hitParticle;
    public ParticleSystem deathParticle;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hitParticle = hitParticle.GetComponent<ParticleSystem>();
        deathParticle = deathParticle.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //For testing puposes only
        if (enemyDeathTest == true)
            Fall();
    }

    public void Hit()
    {
        Debug.Log("Hit Registered");
        Damage();
        hitParticle.Play(true);
    }

    void Damage()
    {        
        //Damages enemy 
        enemyHealth = enemyHealth - 50f; 
        Debug.Log("Target Damaged");
    }

    public void Fall()
    {
        //Rag Doll Effect   
        enemyController.ReturnPoint();
        enemyController.agent.enabled = false;
        rb.isKinematic = false;
        rb.AddForce(playerGun.muzzle.transform.right * force, ForceMode.Impulse);
        rb.AddTorque((transform.forward + transform.up) * rotForce);
        enemyController.dead = true;
        enemyShooting.shooting = false;

        //For Testing purposes only
        enemyDeathTest = false;

        //Calls destroy function after 5 seconds 
        Invoke("Death", 5);
    }

    void Death()
    {
        deathParticle.Play(true);
        //Destroys enemy
        Debug.Log("Drone Destroyed");
        Destroy(gameObject);
    }
}
