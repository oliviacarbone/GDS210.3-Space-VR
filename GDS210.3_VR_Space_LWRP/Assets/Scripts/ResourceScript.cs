﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    //moves the resource after spawning
    public float thrust;
    public Rigidbody rb;
    //a count down to ensure the object is deleted if it flies away
    public float countDown = 20f;
    // Start is called before the first frame update
    void Start()
    {
        countDown = 15f;
        thrust = 125f;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrust);
    }

    // Update is called once per frame
    void Update()
    {

        countDown -= Time.deltaTime;

        if (countDown < 0f)
        {
            Destroy(gameObject);
        }
        
    }

    //moves the resource after spawning
    void FixedUpdate()
    {
      //  rb.AddForce(transform.forward * thrust);
    }


}
