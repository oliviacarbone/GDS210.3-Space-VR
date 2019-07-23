using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //The speed the object will travel at.
    public float thrust;
    //The lifespan of our object.
    public float lifeSpan;
    //A reference to our rigidbody.
    public Rigidbody myRigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        //Gets our rigidbody component.
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the gameobject in a straight line.
        myRigidBody.AddForce(transform.forward * thrust);
        //Destroys our gameObject after it's lifespan.
        Destroy(gameObject, lifeSpan);
    }
}
