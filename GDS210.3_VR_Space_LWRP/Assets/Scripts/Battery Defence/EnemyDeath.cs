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
    public float rotForce;
    private Rigidbody rb;
    public ParticleSystem hitParticle;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hitParticle = hitParticle.GetComponent<ParticleSystem>();
    }

    void Start()
    {
        enemyHealth = 100;
        droneColour.color = Color.white;
        ChangeColor();
        Invoke("ChangeColor", 5);
    }

    public void Hit()
    {
        //Turns test drown red if hit 
        //droneColour.color = Color.red;

        //Calls ChangeColor() after 2 seconds
        Invoke("ChangeColor", 2);
        Debug.Log("Hit Registered");
        Damage();
        hitParticle.Play(true);
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
        //Calls destroy function after 5 seconds 
        Invoke("Death", 5);
    }

    void Death()
    {
        //Destroys enemy
        Debug.Log("Drone Destroyed");
        Destroy(gameObject);
    }
}
