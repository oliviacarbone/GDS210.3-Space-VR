using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public float thrust = 3f;
    public Rigidbody rb;
    public float countDown = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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


    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust);
    }


}
