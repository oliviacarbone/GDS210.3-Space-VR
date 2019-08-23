
using UnityEngine;
using Valve.VR;
public class Gun : MonoBehaviour
{
    public float range = 1000f;

    public LineRenderer laser;

    public GameObject muzzle;
    public Material laserColor;
    public Transform hitPos;

    public ParticleSystem muzzleFlash;

    public LayerMask layerMask;

    Color noTarget = Color.green;
    Color withTarget = Color.red;

    public EnemyDeath enemyDeath;
    public float playerDamage = 50f;

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean shootAction;

    public ScoreScript scorePoint;


    void Start()
    {
        controllerPose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        scorePoint = FindObjectOfType<ScoreScript>();
    }
    void Update()
    {
        Laser();
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Shoot();
        //}
        
        if(shootAction.GetLastStateDown(handType))
        {
            Shoot();
            print("Shot");
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(-Vector3.up) * 10;
        Gizmos.DrawRay(transform.position, direction);
    }

    void Shoot()
    {
        //Raycast for shooting
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, -muzzle.transform.up, out hit, range))
        {
            muzzleFlash.Play(true);
            Debug.Log("Raycast Going Out" + gameObject.tag);
            if (hit.collider.CompareTag("EnemyShip"))
            {
                enemyDeath = hit.collider.GetComponent<EnemyDeath>();

                Debug.Log("HIT!!!");
                enemyDeath.Hit();

                if(enemyDeath.enemyHealth == 0)
                {
                    //Add a point for score
                    scorePoint.currentScore += 1;
                    enemyDeath.Fall();
                }
                else if(enemyDeath.enemyHealth < 0)
                {
                    enemyDeath.Fall();
                }
            }
            //Debug.DrawRay(muzzle.transform.position, muzzle.transform.forward *100, Color.blue, 5);
            //hitPos = hit.transform.position;
        }
    }

    void Laser()
    {
        //Raycast for laser sights
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, -muzzle.transform.up, out hit, range))  
        {
            if (hit.collider.CompareTag("EnemyShip"))
            {
                //Changes colour of laser to red when on a target
                laserColor.color = withTarget;
                laserColor.color = withTarget;
                laser.SetPosition(1, hit.point);
            }
        }
        else
        {
            //Sets default laser colour to green
            laserColor.color = noTarget;
            laserColor.color = noTarget;
            laser.SetPosition(1, -transform.up * 5000);
        }

        if (!hit.collider /*&& hit.collider.CompareTag("IgnoreRaycast")*/)
        {
            //Sets laser distance 
            laser.SetPosition(1, -transform.up * 5000);
            Debug.Log("No Hit");
        }

        //Sets laser start location
        laser.SetPosition(0, muzzle.transform.position);
        
    }
}
