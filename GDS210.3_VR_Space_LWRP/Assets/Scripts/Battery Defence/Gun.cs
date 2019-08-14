
using UnityEngine;
using Valve.VR;
public class Gun : MonoBehaviour
{
    public float range = 100f;

    public LineRenderer laser;

    public GameObject muzzle;
    public Material laserColor;

    Color noTarget = Color.green;
    Color withTarget = Color.red;

    public EnemyDeath enemyDeath;
    public float playerDamage = 50f;

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean shootAction;

    void Update()
    {
        Laser();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
        if(shootAction.GetLastStateUp(handType))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Raycast for shooting
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.up, out hit, range))
        {
            if (hit.collider.CompareTag("EnemyShip"))
            {
                Debug.Log("HIT!!!");
                hit.collider.GetComponent<EnemyDeath>().Hit();
            }
        }
    }

    void Laser()
    {
        //Raycast for laser sights
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.up, out hit, range))  
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
            laser.SetPosition(1, transform.forward * 5000);
        }

        if (!hit.collider)
        {
            //Sets laser distance 
            laser.SetPosition(1, transform.forward * 5000);
            Debug.Log("No Hit");
        }

        //Sets laser start location
        laser.SetPosition(0, muzzle.transform.position);
        
    }
}
