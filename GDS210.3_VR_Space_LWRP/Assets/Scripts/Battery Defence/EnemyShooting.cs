using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject muzzle1;
    public GameObject muzzle2;
    public float speed = 100;
    private float fireRate = 0.5f;
    public float nextFire;
    public bool leftCannon;

    void Start()
    {
        nextFire = 0f;
    }

    void Update()
    {
        Shoot();
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
