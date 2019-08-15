using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject muzzle1;
    public GameObject muzzle2;
    private GameObject target;
    public float range;
    public float speed = 100;
    private float fireRate = 0.5f;
    public float nextFire;
    private bool leftCannon;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Battery");
    }

    void Start()
    {
        nextFire = 0f;
    }

    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <= range)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(Time.time >= nextFire)
        {
            nextFire = fireRate + Time.time;
            
            Vector3 newMuzzle = leftCannon ? muzzle1.transform.position : muzzle2.transform.position;
            GameObject newBullet = Instantiate(enemyBullet, newMuzzle, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            
            leftCannon = !leftCannon;
        }
    }
}
