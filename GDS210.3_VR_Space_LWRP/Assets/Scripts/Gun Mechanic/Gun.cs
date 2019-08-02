
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

    public ShootingTest shootingTest;

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
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.up, out hit, range))
        {
            if (hit.collider.CompareTag("GunTarget"))
            {
                Debug.Log("HIT!!!");
                shootingTest.Hit();
            }
        }
    }

    void Laser()
    {

        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.up, out hit, range))  
        {
            if (hit.collider.CompareTag("GunTarget"))
            {
                laserColor.color = withTarget;
                laserColor.color = withTarget;
                laser.SetPosition(1, hit.point);
            }
        }
        else
        {
            laserColor.color = noTarget;
            laserColor.color = noTarget;
            laser.SetPosition(1, transform.forward * 5000);
        }

        if (!hit.collider)
        {
            laser.SetPosition(1, transform.forward * 5000);
            Debug.Log("No Hit");
        }

        laser.SetPosition(0, muzzle.transform.position);
        
    }
}
