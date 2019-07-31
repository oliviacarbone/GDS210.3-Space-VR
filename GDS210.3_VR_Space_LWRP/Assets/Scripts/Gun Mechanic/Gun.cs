
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;

    public LineRenderer laser;

    public GameObject muzzle;
    public Material laserColor;

    Color noTarget = Color.green;
    Color withTarget = Color.red;

    void Awake()
    {
        // laser = gameObject.GetComponent<LineRenderer>();
        laserColor.color = noTarget;
        laserColor.color = noTarget;
    }

    void Update()
    {
        Laser();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.up, out hit, range))
        {
            Debug.Log("HIT!!!");
        }
    }

    void Laser()
    {

        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.up, out hit, range))
        {
            laserColor.color = withTarget;
            laserColor.color = withTarget;
            laser.SetPosition(1, hit.point);
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
